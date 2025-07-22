using TsysProcessor.Workflow.Context;

namespace TsysProcessor.Processor.TransactionTasks
{
    public class EnqueueTransactionResponse : TsysTaskAsync
    {
        public EnqueueTransactionResponse(TsysWorkflowContext workflowContext) : base(workflowContext)
        {
        }

        protected override Task<bool> RunActiveAsync()
        {
            // implement enqueuing the transaction response.
            // if no response is available, then enqueue a default response.
            return Task.FromResult(true);
        }

        protected override Task<bool> RunErroredAsync()
        {
            // implement enqueuing the transaction response.
            // if no response is available, then enqueue a default response.
            return Task.FromResult(false);
        }
    }
}
