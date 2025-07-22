using TsysProcessor.Workflow.Context;

namespace TsysProcessor.Processor.TransactionTasks
{
    public class BuildResponseEnvelope : TsysTask
    {
        public BuildResponseEnvelope(TsysWorkflowContext workflowContext) : base(workflowContext)
        {
        }

        protected override bool RunActive()
        {
            // TODO: implement building response envelope
            return true;
        }
    }
}
