using Payment.Messages.Serializers;
using TsysProcessor.Processor.TransactionTasks;
using TsysProcessor.Workflow.Context;
namespace TsysProcessor.Processor.Transaction
{
    /// <summary>
    /// Serializes the transaction request message.
    /// </summary>
    /// <remarks>An unsanitized request message is serialized so that it can be sent
    /// to the payment processor. A sanitized version of the request message is serialized
    /// so that it can be saved to the database.</remarks>
    public class SerializeMessage : TsysTask
    {
        private readonly IJsonMessageSerializer jsonSerializer;
        private readonly IStringMessageSerializer stringSerializer;

        /// <summary>
        /// Creates an instance of the task.
        /// </summary>
        /// <param name="workflowContext">The workflow context in which the task runs.</param>
        /// <param name="jsonSerializer">A JSON serializer that provides sanitization and formatting.</param>
        /// <param name="stringSerializer">A string serializer that supports sanitization and formatting.</param>
        public SerializeMessage(TsysWorkflowContext workflowContext, IJsonMessageSerializer jsonSerializer, IStringMessageSerializer stringSerializer) : base(workflowContext)
        {
            this.jsonSerializer = jsonSerializer;
            this.stringSerializer = stringSerializer;
        }

        protected override bool RunActive()
        {
            if (WorkflowContext.RequestMessage == null)
                throw new ArgumentNullException("RequestMessage is required.");

            // TODO: decide if json message should be flattened (which would be consistent with Core and Quad).
            WorkflowContext.SerializedRequest = stringSerializer.SerializeMessage(WorkflowContext.RequestMessage);
            WorkflowContext.SanitizedRequest = jsonSerializer.SerializeMessage(WorkflowContext.RequestMessage, true);

            return true;
        }
    }
}
