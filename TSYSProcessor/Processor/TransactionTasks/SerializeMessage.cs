using Payment.Messages.Serializers;
using TsysProcessor.Processor.TransactionTasks;
using TsysProcessor.Workflow.Context;
namespace TsysProcessor.Processor.Transaction
{
    public class SerializeMessage : TsysTask
    {
        private readonly IMessageSerializer serializer;

        public SerializeMessage(TsysWorkflowContext processContext, IMessageSerializer serializer) : base(processContext)
        {
            this.serializer = serializer;
        }

        protected override bool RunActive()
        {
            if (WorkflowContext.RequestMessage == null)
                throw new ArgumentNullException("RequestMessage is required.");

            WorkflowContext.SerializedRequest = serializer.SerializeMessage(WorkflowContext.RequestMessage);
            return true;
        }
    }
}
