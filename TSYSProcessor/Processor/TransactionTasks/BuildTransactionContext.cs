using Payment.Processor.Builders;
using Payment.Processor.Transaction.Context;
using TsysProcessor.Workflow.Context;
using TsysProcessor.Transaction.Context;
using TsysProcessor.Transaction.Model;
using TsysProcessor.Processor.TransactionTasks;

namespace TsysProcessor.Processor.TransactionSteps
{
    class BuildTransactionContext : TsysTaskAsync
    {
        private readonly IBuilder<ActionContext> actionContextBuilder;
        private readonly IBuilderAsync<CardContext> cardContextBuilder;
        private readonly IBuilder<CardOnFileContext> cardOnFileContextBuilder;
        private readonly IBuilder<TsysEnvelope> envelopeBuilder;
        private readonly IBuilder<ReaderContext> readerContextBuilder;

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
