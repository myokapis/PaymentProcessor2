using TsysProcessor.Workflow.Context;

namespace TsysProcessor.Processor.TransactionTasks
{
    public class ParseResponse : TsysTask
    {
        public ParseResponse(TsysWorkflowContext workflowContext) : base(workflowContext)
        {
        }

        protected override bool RunActive()
        {
            // TODO: implement response parsing
            return true;
        }
    }
}
