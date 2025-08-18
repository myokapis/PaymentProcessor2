using Payment.Processor.Builders;
using TsysProcessor.Workflow.Context;
using TsysProcessor.Transaction.Context;
using TsysProcessor.Transaction.Model;
using TsysProcessor.Processor.TransactionTasks;

namespace TsysProcessor.Processor.TransactionSteps
{
    /// <summary>
    /// Builds a transaction context for a transaction.
    /// </summary>
    class BuildTransactionContext : TsysTaskAsync
    {
        private readonly ITransactionContextBuilder<TsysEnvelope, TsysProcessorAttributes> transactionContextBuilder;

        /// <summary>
        /// Creates an instance of the task.
        /// </summary>
        /// <param name="workflowContext">The workflow context in which the task runs.</param>
        /// <param name="actionContextBuilder">A builder to construct a sub-context describing the transaction action.</param>
        /// <param name="cardContextBuilder">A builder to construct a sub-context describing the card.</param>
        /// <param name="cardOnFileContextBuilder">A builder to construct a sub-context describing card on file attributes.</param>
        /// <param name="envelopeBuilder">A builder to construct a request envelope for the transaction.</param>
        /// <param name="readerContextBuilder">A builder to construct a sub-context describing the reader.</param>
        public BuildTransactionContext(TsysWorkflowContext workflowContext,
            ITransactionContextBuilder<TsysEnvelope, TsysProcessorAttributes> transactionContextBuilder

        ) : base(workflowContext)
        {
            this.transactionContextBuilder = transactionContextBuilder;
            //this.actionContextBuilder = actionContextBuilder;
            //this.cardContextBuilder = cardContextBuilder;
            //this.cardOnFileContextBuilder = cardOnFileContextBuilder;
            //this.envelopeBuilder = envelopeBuilder;
            //this.readerContextBuilder = readerContextBuilder;
        }

        protected override async Task<bool> RunActiveAsync()
        {
            if (WorkflowContext.Transaction is not TsysTransaction transaction)
                throw new ArgumentNullException("Transaction");

            var transactionContext = await transactionContextBuilder.BuildAsync<TsysTransactionContext>(transaction);
            WorkflowContext.TransactionContext = transactionContext;

            return true;
        }
    }
}
