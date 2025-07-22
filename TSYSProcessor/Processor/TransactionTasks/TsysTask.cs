using Payment.Workflow;
using TsysProcessor.Workflow.Context;

namespace TsysProcessor.Processor.TransactionTasks
{
    public abstract class TsysTask : WorkflowTask<TsysWorkflowContext>
    {
        public TsysTask(TsysWorkflowContext workflowContext) : base(workflowContext)
        {
        }
    }
}
