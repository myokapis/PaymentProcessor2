using TsysProcessor.Workflow.Context;

namespace TsysProcessor.Processor.TransactionTasks
{
    public class SaveResponse : TsysTaskAsync
    {
        public SaveResponse(TsysWorkflowContext workflowContext) : base(workflowContext)
        {
        }

        protected override Task<bool> RunActiveAsync()
        {
            // TODO: implement saving response and response envelope
            return Task.FromResult(true);
        }
    }
}
