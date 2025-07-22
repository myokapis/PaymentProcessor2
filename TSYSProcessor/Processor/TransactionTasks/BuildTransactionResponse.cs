using TsysProcessor.Workflow.Context;

namespace TsysProcessor.Processor.TransactionTasks
{
    public class BuildTransactionResponse : TsysTask
    {
        public BuildTransactionResponse(TsysWorkflowContext workflowContext) : base(workflowContext)
        {
        }

        protected override bool RunActive()
        {
            // TODO: build a transaction response to be enqueued
            return true;
        }
    }
}
