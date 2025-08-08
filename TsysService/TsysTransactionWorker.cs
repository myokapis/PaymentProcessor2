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

namespace TsysService
{
    public class TsysTransactionWorker : QueueServiceWorker<TsysTransaction, ResultMessage>
    {
        private int unstatusedRequests = 0;

        public TsysTransactionWorker(IOptions<QueueServiceConfig> config, IAmazonSQS sqsClient, IServiceScopeFactory scopeFactory) : base(config, sqsClient, scopeFactory)
        {}

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

        protected override IWorkflowRunner<IPaymentWorkflowContext<TsysTransaction, ResultMessage>> GetTransactionRunner(IServiceScope scope)
        {
            return scope.ServiceProvider.GetRequiredService<IWorkflowRunner<IPaymentWorkflowContext<TsysTransaction, ResultMessage>>>();
        }

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

        protected override void SendHealthCheck()
        {
            if (nextHealthCheck > DateTime.UtcNow) return;

            var healthCheckTemplate = $"{0} is active with {1} rate limit events and {2} unstatused requests.";
            Log.Information(healthCheckTemplate, GetType().Name, rateLimitEvents, unstatusedRequests);

            rateLimitEvents = 0;
            unstatusedRequests = 0;

            nextHealthCheck = DateTime.UtcNow.AddMinutes(config.HealthCheckIntervalMinutes);
        }
    }
}
