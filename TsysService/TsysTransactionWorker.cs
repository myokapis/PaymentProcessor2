using System.Text.Json;
using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Options;
using Payment.Processor.Enums;
using Payment.Processor.Transaction.Result;
using Payment.Service;
using Payment.Workflow.Interfaces;
using Serilog;
using TsysProcessor.Transaction.Model;
using TsysProcessor.Workflow.Context;

namespace TsysService
{
    /// <summary>
    /// Describes a TSYS variant of the QueueServiceWorker.
    /// </summary>
    public class TsysTransactionWorker : QueueServiceWorker<TsysTransaction, ResultMessage>
    {
        private int unstatusedRequests = 0;

        /// <summary>
        /// Creates a TsysTransactionWorker.
        /// </summary>
        /// <param name="config">The queue service configuration.</param>
        /// <param name="sqsClient">An AWS SQS client.</param>
        /// <param name="scopeFactory">A factory for providing new dependency injection scopes.</param>
        public TsysTransactionWorker(IOptions<IQueueServiceConfig> config, IAmazonSQS sqsClient, IServiceScopeFactory scopeFactory) : base(config, sqsClient, scopeFactory)
        {}

        /// <summary>
        /// Creates an instance of TSYS-specific processing values.
        /// </summary>
        /// <param name="message">The transaction request message to be processed.</param>
        /// <param name="timestamp">The time at which the message was dequeued.</param>
        /// <returns>Processing values for a specific transaction model.</returns>
        protected override IProcessingValues<TsysTransaction> GetProcessingValues(Message message, DateTime timestamp)
        {
            var tsysTransaction = JsonSerializer.Deserialize<TsysTransaction>(message.Body);
            var isValid = ValidateTransaction(tsysTransaction);
            var token = tsysTransaction?.Details?.Id ?? TokenParser.ParseToken(message.Body);

            return new TsysProcessingValues()
            {
                HasValidTransaction = isValid,
                Message = message,
                TaskId = isValid ? NextTaskId() : 0,
                Timestamp = timestamp,
                Token = token,
                Transaction = tsysTransaction
            };
        }

        /// <summary>
        /// Creates an instance of a transaction runner that processes a TSYS-specific transaction model and returns a transaction result.
        /// </summary>
        /// <param name="scope">An instance of a dependency injection scope.</param>
        /// <returns>A workflow runner for a TSYS-specific transaction model and transaction result.</returns>
        protected override IWorkflowRunner<IPaymentWorkflowContext<TsysTransaction, ResultMessage>> GetTransactionRunner(IServiceScope scope)
        {
            return scope.ServiceProvider.GetRequiredService<IWorkflowRunner<IPaymentWorkflowContext<TsysTransaction, ResultMessage>>>();
        }

        /// <summary>
        /// Handles messages containing invalid transactions.
        /// </summary>
        /// <param name="processingValues">The processing values for a transaction message.</param>
        /// <returns>A task with no result.</returns>
        /// <remarks>When no request token is available, a counter is incremented for logging.
        /// Otherwise, a processing error result is enqueued to ensure that Gateway receives a status
        /// for the transaction.</remarks>
        protected override async Task HandleInvalidMessage(IProcessingValues<TsysTransaction> processingValues)
        {
            if (processingValues.Token == null)
            {
                unstatusedRequests++;
            }
            else
            {
                var resultModel = new ResultMessage()
                {
                    Id = processingValues.Token,
                    Result = TransactionResult.ProcessingError
                };

                await EnqueueResult(resultModel);
            }
        }

        /// <summary>
        /// Enqueues auto void and timeout reversal job payloads
        /// </summary>
        /// <param name="workflowContext"></param>
        /// <param name="processingValues"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        protected async override Task PostProcessing(IPaymentWorkflowContext<TsysTransaction, ResultMessage> workflowContext, IProcessingValues<TsysTransaction> processingValues)
        {
            var tsysConfig = (TsysQueueServiceConfig)config;
            var tsysContext = (TsysWorkflowContext)workflowContext;
            var responseContext = tsysContext.ResponseContext;
            if (responseContext == null) return;

            if (responseContext.RequiresVoiding)
                await EnqueueVoid(responseContext.AutoVoidModel, tsysConfig.AutoVoidQueueUrl, processingValues.Token);
            else if (responseContext.RequiresTimeoutReversal)
                await EnqueueVoid(responseContext.TimeoutReversalModel, tsysConfig.TimeoutReversalQueueUrl, processingValues.Token);
        }

        // TODO: do Splunk or NewRelic need to be incorporated here?
        /// <summary>
        /// Logs a health check if the current health check interval has expired.
        /// </summary>
        protected override void SendHealthCheck()
        {
            if (nextHealthCheck > DateTime.UtcNow) return;

            var healthCheckTemplate = $"{0} is active with {1} rate limit events and {2} unstatused requests.";
            Log.Information(healthCheckTemplate, GetType().Name, rateLimitEvents, unstatusedRequests);

            rateLimitEvents = 0;
            unstatusedRequests = 0;

            nextHealthCheck = nextHealthCheck.AddMinutes(config.HealthCheckIntervalMinutes);
        }

        // TODO: define a class for the model instead of object
        private async Task EnqueueVoid(object? voidModel, string queueUrl, string? token)
        {
            if (voidModel == null)
            {
                Log.Warning("Reversal payload was missing for transaction, {0}", token);
                return;
            }

            var voidPayload = JsonSerializer.Serialize(voidModel);
            await sqsClient.SendMessageAsync(queueUrl, voidPayload);
        }
    }
}
