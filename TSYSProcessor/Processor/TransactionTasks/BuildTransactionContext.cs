using Payment.Processor.Builders;
using Payment.Processor.Transaction.Context;
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
        private readonly IBuilder<ActionContext> actionContextBuilder;
        private readonly IBuilderAsync<CardContext> cardContextBuilder;
        private readonly IBuilder<CardOnFileContext> cardOnFileContextBuilder;
        private readonly IBuilder<TsysEnvelope> envelopeBuilder;
        private readonly IBuilder<ReaderContext> readerContextBuilder;

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
            IBuilder<ActionContext> actionContextBuilder,
            IBuilderAsync<CardContext> cardContextBuilder,
            IBuilder<CardOnFileContext> cardOnFileContextBuilder,
            IBuilder<TsysEnvelope> envelopeBuilder,
            IBuilder<ReaderContext> readerContextBuilder) : base(workflowContext)
        {
            this.actionContextBuilder = actionContextBuilder;
            this.cardContextBuilder = cardContextBuilder;
            this.cardOnFileContextBuilder = cardOnFileContextBuilder;
            this.envelopeBuilder = envelopeBuilder;
            this.readerContextBuilder = readerContextBuilder;
        }

        protected override async Task<bool> RunActiveAsync()
        {
            if (WorkflowContext.Transaction is not TsysTransaction transaction)
                throw new ArgumentNullException("Transaction");

            var actionContext = actionContextBuilder.Build(transaction);
            var cardContext = await cardContextBuilder.BuildAsync(transaction);
            var cardOnFileContext = cardOnFileContextBuilder.Build(transaction, actionContext);
            var envelope = envelopeBuilder.Build(transaction);
            var readerContext = readerContextBuilder.Build(transaction);

            var transactionContext = new TsysTransactionContext()
            {
                ActionContext = actionContext,
                CardContext = cardContext,
                CardOnFileContext = cardOnFileContext,
                Details = transaction.Details,
                Envelope = envelope,
                Merchant = transaction.Merchant,
                ProcessorAttributes = transaction.ProcessorAttributes,
                ReaderContext = readerContext
            };

            WorkflowContext.TransactionContext = transactionContext;

            return true;
        }
    }
}
