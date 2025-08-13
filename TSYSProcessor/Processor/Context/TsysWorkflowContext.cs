using Payment.Messages;
using Payment.Processor.Transaction.Result;
using Payment.Workflow;
using Payment.Workflow.Interfaces;
using TsysProcessor.Responses;
using TsysProcessor.Transaction.Context;
using TsysProcessor.Transaction.Model;

namespace TsysProcessor.Workflow.Context
{
    public class TsysWorkflowContext : WorkflowContext, IPaymentWorkflowContext<TsysTransaction, ResultMessage>
    {
        /// <summary>
        /// The unique value locking value associated with the current transaction.
        /// </summary>
        public string? LockHandle { get; set; }

        /// <summary>
        /// The decoded processor response from TSYS. 
        /// </summary>
        public TsysResponse? ProcessorResponse { get; set; }

        /// <summary>
        /// The raw string response from TSYS.
        /// </summary>
        public string? RawProcessorResponse { get; set; }

        public IAccessibleMessage? RequestMessage { get; set; }

        /// <summary>
        /// A context describing the state of the response and various other attributes.
        /// </summary>
        public TsysResponseContext? ResponseContext { get; set; }

        /// <summary>
        /// The envelope containing values to be persisted for use with associated transactions.
        /// </summary>
        public TsysResponseEnvelope? ResponseEnvelope { get; set; }
        
        public string? SanitizedRequest { get; set; }
        public string? SerializedRequest { get; set; }
        public TsysTransaction? Transaction { get; set; }
        public TsysTransactionContext? TransactionContext { get; set; }
        public ResultMessage? TransactionResult { get; set; }
    }
}
