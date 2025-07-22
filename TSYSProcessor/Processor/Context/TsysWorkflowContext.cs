using Payment.Messages;
using Payment.Workflow;
using TsysProcessor.Transaction.Context;
using TsysProcessor.Transaction.Model;

namespace TsysProcessor.Workflow.Context
{
    public class TsysWorkflowContext : WorkflowContext
    {
        public object? ProcessorResponse { get; set; }
        public IAccessibleMessage? RequestMessage { get; set; }
        public string? SerializedRequest { get; set; }
        public TsysTransaction? Transaction { get; set; }
        public TsysTransactionContext? TransactionContext { get; set; }
    }
}
