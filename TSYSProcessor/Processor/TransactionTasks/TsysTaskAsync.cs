using Payment.Workflow;
using TsysProcessor.Workflow.Context;

namespace TsysProcessor.Processor.TransactionTasks
{
    public abstract class TsysTaskAsync : WorkflowTaskAsync<TsysWorkflowContext>
    {
        public TsysTaskAsync(TsysWorkflowContext workflowContext) : base(workflowContext)
        {
        }
    }
}
