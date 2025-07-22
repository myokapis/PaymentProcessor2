using TsysProcessor.Processor.TransactionTasks;
using TsysProcessor.Workflow.Context;

namespace TsysProcessor.Processor.TransactionSteps
{
    public class SendMessage : TsysTaskAsync
    {
        public SendMessage(TsysWorkflowContext workflowContext) : base(workflowContext)
        { }

        protected override async Task<bool> RunActiveAsync()
        {
            var requestMessage = WorkflowContext.RequestMessage;
            if (requestMessage == null) throw new ArgumentNullException("Request message is required.");

            // TODO: send request and set raw response
            WorkflowContext.ProcessorResponse = "";
            return true;
        }
    }
}
