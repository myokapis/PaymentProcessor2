using Payment.Workflow;
using TsysProcessor.Workflow.Context;

namespace TsysProcessor.Processor.TransactionTasks
{
    public abstract class TsysTaskAsync : WorkflowTaskAsync<TsysWorkflowContext>
    {
        /// <summary>
        /// A workflow task that runs asynchronously in a TSYS-specific workflow context.
        /// </summary>
        /// <param name="workflowContext">The workflow context in which the task runs.</param>
        public TsysTaskAsync(TsysWorkflowContext workflowContext) : base(workflowContext)
        {
        }
    }
}
