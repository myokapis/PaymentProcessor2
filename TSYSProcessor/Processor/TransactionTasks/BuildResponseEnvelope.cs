using TsysProcessor.Responses;
using TsysProcessor.Workflow.Context;

namespace TsysProcessor.Processor.TransactionTasks
{
    /// <summary>
    /// Builds a response envelope.
    /// </summary>
    public class BuildResponseEnvelope : TsysTask
    {
        /// <summary>
        /// Creates an instance of the task.
        /// </summary>
        /// <param name="workflowContext">The workflow context in which the task runs.</param>
        public BuildResponseEnvelope(TsysWorkflowContext workflowContext) : base(workflowContext)
        {
        }

        protected override bool RunActive()
        {
            // TODO: implement building response envelope
            //       should this only occur for approved requests?
            WorkflowContext.ResponseEnvelope = new TsysResponseEnvelope();

            return true;
        }
    }
}
