using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Payment.Workflow.Interfaces;
using Serilog;


// TODO: add sanitization on logs (see Isaac's project)
namespace Payment.Service
{
    /// <summary>
    /// An abstract class for creating long-running background services for payment processing.
    /// </summary>
    /// <typeparam name="TTransaction">The type of the transaction model to be processed.</typeparam>
    /// <typeparam name="TResult">The type of the transaction result produced by the processing service.</typeparam>
    public abstract class QueueServiceWorker<TTransaction, TResult> : BackgroundService
        where TTransaction : class
        where TResult : class
    {
        protected IQueueServiceConfig config;
        protected DateTime nextHealthCheck = DateTime.UtcNow;
        protected int rateLimitEvents = 0;
        protected ConcurrentDictionary<uint, DateTime> runningTasks = new();
        protected IAmazonSQS sqsClient;
        protected IServiceScopeFactory scopeFactory;
        protected uint taskId = 0;

        /// <summary>
        /// Creates an instance of the queue service worker.
        /// </summary>
        /// <param name="config">The configuration for the service.</param>
        /// <param name="sqsClient">An AWS SQS client.</param>
        /// <param name="scopeFactory">A factory for creating dependency injection scopes.</param>
        public QueueServiceWorker(IOptions<IQueueServiceConfig> config, IAmazonSQS sqsClient, IServiceScopeFactory scopeFactory)
        {
            this.config = config.Value;
            this.sqsClient = sqsClient;
            this.scopeFactory = scopeFactory;
        }

        /// <summary>
        /// Deletes a message from the transaction queue.
        /// </summary>
        /// <param name="receiptHandle">The receipt handle for the message to be deleted.</param>
        /// <returns>A task with no result.</returns>
        protected virtual async Task DeleteTransactionFromQueue(string receiptHandle)
        {
            await sqsClient.DeleteMessageAsync(config.TransactionQueueUrl, receiptHandle);
        }

        /// <summary>
        /// Enqueues the transaction processing result in the transaction result SQS queue.
        /// </summary>
        /// <param name="result">The transaction result message to enqueue.</param>
        /// <returns>A task with no result.</returns>
        protected virtual async Task EnqueueResult(TResult result)
        {
            var resultMessage = JsonSerializer.Serialize(result);
            await sqsClient.SendMessageAsync(config.ResultQueueUrl, resultMessage);
        }

        /// <summary>
        /// The entry point for running the queue worker background service.
        /// </summary>
        /// <param name="stoppingToken">A cancellation token for stopping the background service.</param>
        /// <returns>A task with no result.</returns>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var messageRequest = new ReceiveMessageRequest()
            {
                MaxNumberOfMessages = config.MaxMessagesRequested,
                QueueUrl = config.TransactionQueueUrl,
                VisibilityTimeout = config.MessageVisibilityTimeoutSeconds,
                WaitTimeSeconds = config.QueuePollingSeconds
            };

            while (!stoppingToken.IsCancellationRequested)
            {
                SendHealthCheck();

                if (WithinRateLimit())
                {
                    var messageResponse = await sqsClient.ReceiveMessageAsync(messageRequest);
                    if (messageResponse != null) await ProcessMessages(messageResponse.Messages, stoppingToken);
                }
                else
                {
                    rateLimitEvents++;
                    await Task.Delay(config.RateLimitDelayMilliseconds);
                }
            }

            Console.WriteLine("Shutting down");
            await Task.CompletedTask;
        }

        /// <summary>
        /// Creates an instance of processing values from a transaction request message.
        /// </summary>
        /// <param name="message">The transaction request message to be processed.</param>
        /// <param name="timestamp">The time at which the message was dequeued.</param>
        /// <returns>Processing values for a specific transaction model.</returns>
        protected abstract IProcessingValues<TTransaction> GetProcessingValues(Message message, DateTime timestamp);

        /// <summary>
        /// Creates an instance of a transaction runner that processes a specific transaction model and returns a specific type of transaction result.
        /// </summary>
        /// <param name="scope">An instance of a dependency injection scope.</param>
        /// <returns>A workflow runner for a specific transaction model and transaction result.</returns>
        protected abstract IWorkflowRunner<IPaymentWorkflowContext<TTransaction, TResult>> GetTransactionRunner(IServiceScope scope);

        /// <summary>
        /// Implements logic for handling messages containing invalid transactions.
        /// </summary>
        /// <param name="processingValues">The processing values for a transaction message.</param>
        /// <returns>A task with no result.</returns>
        protected abstract Task HandleInvalidMessage(IProcessingValues<TTransaction> processingValues);

        /// <summary>
        /// Handles any post processing work to be done.
        /// </summary>
        /// <param name="workflowContext">The workflow context in which the process is running.</param>
        /// <param name="processingValues">The processing values derived from the transaction message to be processed.</param>
        /// <returns>A task with no result.</returns>
        /// <remarks>This method is intended to be overridden when additional actions such as enqueuing
        /// timeout reversal or auto void jobs needs to be done.</remarks>
        protected abstract Task PostProcessing(IPaymentWorkflowContext<TTransaction, TResult> workflowContext, IProcessingValues<TTransaction> processingValues);

        /// <summary>
        /// Increments the task counter and returns the result.
        /// </summary>
        /// <returns>A unique unsigned integer representing the identifier of the next task to be created.</returns>
        protected virtual uint NextTaskId()
        {
            return taskId++;
        }

        /// <summary>
        /// Validates a set of transaction messages and starts background tasks to process each message.
        /// </summary>
        /// <param name="messages">The collection of messages to validate and process.</param>
        /// <param name="stoppingToken">A cancellation token for stopping the background tasks.</param>
        /// <returns>A task with no result.</returns>
        protected virtual async Task ProcessMessages(List<Message> messages, CancellationToken stoppingToken)
        {
            var timestamp = DateTime.UtcNow;

            foreach (var message in messages)
            {
                var processingValues = GetProcessingValues(message, timestamp);

                if (!processingValues.HasValidTransaction)
                {
                    await HandleInvalidMessage(processingValues);
                }
                else
                {
                    var scope = scopeFactory.CreateScope();
                    var transactionRunner = GetTransactionRunner(scope);
                    _ = Task.Factory.StartNew(() => ProcessTransaction(transactionRunner, processingValues), stoppingToken);
                }

                // TODO: this is fine for regular transactions, but it won't do for timeout reversals
                //       since we will need to leave the transaction enqueued until it succeeds or 
                //       reaches its max attempts.
                await DeleteTransactionFromQueue(processingValues.Message.ReceiptHandle);
            }
        }

        /// <summary>
        /// Processses a transaction and enqueues the result message.
        /// </summary>
        /// <param name="transactionRunner">An instance of a workflow runner for processing the transaction.</param>
        /// <param name="processingValues">The processing values derived from the transaction message to be processed.</param>
        /// <returns>A task with no result.</returns>
        protected virtual async Task ProcessTransaction(IWorkflowRunner<IPaymentWorkflowContext<TTransaction, TResult>> transactionRunner, IProcessingValues<TTransaction> processingValues)
        {
            try
            {
                transactionRunner.WorkflowContext.Transaction = processingValues.Transaction;
                await transactionRunner.RunAsync();
                var resultMessage = transactionRunner.WorkflowContext.TransactionResult;

                // NOTE: payment processors are designed to always return a result; however, this logic is a fail safe
                if (resultMessage == null)
                    Log.Error("No result was returned for {0}", processingValues.Token);
                else
                {
                    await EnqueueResult(resultMessage);
                    await PostProcessing(transactionRunner.WorkflowContext, processingValues);
                }

                runningTasks.TryRemove(processingValues.TaskId, out _);
            }
            // TODO: may need to trap and ignore errors related to cancellation
            catch (Exception e)
            {
                // TODO: sanitize error
                Log.Error(e, $"Error in task for {0}", processingValues.Token);
            }
        }

        // TODO: should this be an async method?
        /// <summary>
        /// A hook method for sending a health check message to a logger or monitoring service.
        /// Inheriting classes can include other functionality such as logging transaction counts
        /// or other useful information.
        /// </summary>
        protected abstract void SendHealthCheck();

        /// <summary>
        /// Validates a transaction.
        /// </summary>
        /// <param name="transaction">The transaction to be validated.</param>
        /// <returns>True if the transaction is valid.</returns>
        protected virtual bool ValidateTransaction(TTransaction? transaction)
        {
            if (transaction == null) return false;

            var validationContext = new ValidationContext(transaction);
            var validationResults = new List<ValidationResult>();
            return Validator.TryValidateObject(transaction, validationContext, validationResults, true);
        }

        /// <summary>
        /// Checks the number of unexpired background tasks against the maximum number of
        /// background tasks allowed.
        /// </summary>
        /// <returns>True if the number of unexpired background tasks is within the allowed limit.</returns>
        protected virtual bool WithinRateLimit()
        {
            var runningTaskCount = runningTasks.Count;

            if (runningTaskCount > config.MaxWorkerTasks)
            {
                var expirationTime = DateTime.UtcNow.AddSeconds(config.TaskExpirationSeconds);
                var expiredTasks = runningTasks.Where(t => t.Value < expirationTime).ToArray();
                runningTaskCount -= expiredTasks.Length;

                foreach (var expiredTask in expiredTasks)
                {
                    runningTasks.TryRemove(expiredTask);
                }
            }

            return runningTaskCount <= config.MaxWorkerTasks;
        }
    }
}
