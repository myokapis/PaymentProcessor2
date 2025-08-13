using TsysProcessor.Responses;
using TsysProcessor.Workflow.Context;

namespace TsysProcessor.Processor.TransactionTasks
{
    /// <summary>
    /// Parses the raw Tsys response into a response model.
    /// </summary>
    public class ParseResponse : TsysTask
    {
        /// <summary>
        /// Creates an instance of the task.
        /// </summary>
        /// <param name="workflowContext">The workflow context in which the task runs.</param>
        public ParseResponse(TsysWorkflowContext workflowContext) : base(workflowContext)
        {
        }

        protected override bool RunActive()
        {
            var rawResponse = WorkflowContext.RawProcessorResponse;

            // TODO: implement response parsing from the raw response
            WorkflowContext.ProcessorResponse = new TsysResponse();

            return true;
        }
    }
}
