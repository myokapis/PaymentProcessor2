using TsysProcessor.Workflow.Context;

namespace TsysProcessor.Processor.TransactionTasks
{
    /// <summary>
    /// Saves the response and response envelope toe the database.
    /// </summary>
    public class SaveResponse : TsysTaskAsync
    {
        /// <summary>
        /// Creates an instance of the task.
        /// </summary>
        /// <param name="workflowContext">The workflow context in which the task runs.</param>
        public SaveResponse(TsysWorkflowContext workflowContext) : base(workflowContext)
        {
        }

        protected override Task<bool> RunActiveAsync()
        {
            var response = WorkflowContext.ProcessorResponse;
            var envelope = WorkflowContext.ResponseEnvelope;
            // TODO: decide what to do if by chance the response or envelope is missing.
            //       seems like we should still save any data that we have.

            // TODO: implement saving response and response envelope
            return Task.FromResult(true);
        }
    }
}
