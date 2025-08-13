using Payment.Workflow;
using TsysProcessor.Workflow.Context;

namespace TsysProcessor.Processor.TransactionTasks
{
    public abstract class TsysTask : WorkflowTask<TsysWorkflowContext>
    {
        /// <summary>
        /// A workflow task that runs in a TSYS-specific workflow context.
        /// </summary>
        /// <param name="workflowContext">The workflow context in which the task runs.</param>
        public TsysTask(TsysWorkflowContext workflowContext) : base(workflowContext)
        {
        }
    }
}
