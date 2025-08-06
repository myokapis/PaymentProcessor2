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
    public abstract class ServiceWorker<TTransaction, TResult> : BackgroundService
        where TTransaction : class
        where TResult : class
    {
        protected ServiceConfig config;
        protected DateTime nextHealthCheck = DateTime.UtcNow;
        protected int rateLimitEvents = 0;
        protected ConcurrentDictionary<uint, DateTime> runningTasks = new();
        protected IAmazonSQS sqsClient;
        protected IServiceScopeFactory scopeFactory;
        protected uint taskId = 0;

        public ServiceWorker(IOptions<ServiceConfig> config, IAmazonSQS sqsClient, IServiceScopeFactory scopeFactory)
        {
            this.config = config.Value;
            this.sqsClient = sqsClient;
            this.scopeFactory = scopeFactory;
        }

        protected virtual async Task DeleteFromQueue(string receiptHandle)
        {
            await sqsClient.DeleteMessageAsync(config.TransactionQueueUrl, receiptHandle);
        }

        protected virtual async Task EnqueueResult(TResult result)
        {
            var resultMessage = JsonSerializer.Serialize(result);
            await sqsClient.SendMessageAsync(config.ResultQueueUrl, resultMessage);
        }

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

        protected abstract IProcessingValues<TTransaction> GetProcessingValues(Message message, DateTime timestamp);

        protected abstract IWorkflowRunner<IPaymentWorkflowContext<TTransaction, TResult>> GetTransactionRunner(IServiceScope scope);

        protected abstract Task HandleInvalidMessage(IProcessingValues<TTransaction> processingValues);

        protected virtual uint NextTaskId()
        {
            return taskId++;
        }

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

                await DeleteFromQueue(processingValues.Message.ReceiptHandle);
            }
        }

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
                    await EnqueueResult(resultMessage);

                runningTasks.TryRemove(processingValues.TaskId, out _);
            }
            // TODO: may need to trap and ignore errors related to cancellation
            catch (Exception e)
            {
                // TODO: sanitize error
                Log.Error(e, $"Error in task for {0}", processingValues.Token);
            }
        }

        protected abstract void SendHealthCheck();

        protected virtual bool ValidateTransaction(TTransaction? tsysTransaction)
        {
            if (tsysTransaction == null) return false;

            var validationContext = new ValidationContext(tsysTransaction);
            var validationResults = new List<ValidationResult>();
            return Validator.TryValidateObject(tsysTransaction, validationContext, validationResults, true);
        }

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
