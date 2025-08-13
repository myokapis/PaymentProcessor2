using TsysProcessor.Processor.TransactionTasks;
using TsysProcessor.Workflow.Context;

namespace TsysProcessor.Processor.TransactionSteps
{
    /// <summary>
    /// Sends the transaction request message to the TSYS payment processor.
    /// </summary>
    public class SendMessage : TsysTaskAsync
    {
        /// <summary>
        /// Creates an instance of the task.
        /// </summary>
        /// <param name="workflowContext">The workflow context in which the task runs.</param>
        public SendMessage(TsysWorkflowContext workflowContext) : base(workflowContext)
        { }

        protected override async Task<bool> RunActiveAsync()
        {
            var requestMessage = WorkflowContext.RequestMessage;
            if (requestMessage == null) throw new ArgumentNullException("Request message is required.");

            // TODO: send request to the payment processor and set raw response on the workflow context.
            //       be sure to inject the http client in the constructor.
            //       be sure to set a timeout on the http client. (timeout must be less than the transaction expiration window.)
            WorkflowContext.RawProcessorResponse = "";

            return await Task.FromResult(true);
        }
    }
}
