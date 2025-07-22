using Payment.Workflow;
using TsysProcessor.Workflow.Context;

namespace TsysProcessor.Processor.TransactionTasks
{
    public abstract class TsysTaskAsync : WorkflowTaskAsync<TsysWorkflowContext>
    {
        protected TsysTaskAsync(TsysWorkflowContext workflowContext) : base(workflowContext)
        {
        }
    }
}
