using TsysProcessor.Workflow.Context;

namespace TsysProcessor.Processor.TransactionTasks
{
    public class SaveMessage : TsysTaskAsync
    {
        public SaveMessage(TsysWorkflowContext workflowContext) : base(workflowContext)
        {
        }

        protected override Task<bool> RunActiveAsync()
        {
            // TODO: implement saving sanitized message to the database
            return Task.FromResult(true);
        }
    }
}
