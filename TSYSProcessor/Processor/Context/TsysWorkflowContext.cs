using Payment.Messages;
using Payment.Processor.Transaction.Result;
using Payment.Workflow;
using Payment.Workflow.Interfaces;
using TsysProcessor.Transaction.Context;
using TsysProcessor.Transaction.Model;

namespace TsysProcessor.Workflow.Context
{
    public class TsysWorkflowContext : WorkflowContext, IPaymentWorkflowContext<TsysTransaction, ResultMessage>
    {
        public object? ProcessorResponse { get; set; }
        public IAccessibleMessage? RequestMessage { get; set; }
        public ResultMessage? TransactionResult { get; set; }
        public string? SerializedRequest { get; set; }
        public TsysTransaction? Transaction { get; set; }
        public TsysTransactionContext? TransactionContext { get; set; }
    }
}
