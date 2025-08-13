using TsysProcessor.Workflow.Context;

namespace TsysProcessor.Processor.TransactionTasks
{
    /// <summary>
    /// Saves the serialized, sanitized transaction message.
    /// </summary>
    public class SaveMessage : TsysTaskAsync
    {
        /// <summary>
        /// Creates an instance of the task.
        /// </summary>
        /// <param name="workflowContext">The workflow context in which the task runs.</param>
        public SaveMessage(TsysWorkflowContext workflowContext) : base(workflowContext)
        {
        }

        protected override Task<bool> RunActiveAsync()
        {
            var sanitizedMessage = WorkflowContext.SerializedRequest;

            // TODO: implement saving sanitized message to the database
            return Task.FromResult(true);
        }
    }
}
