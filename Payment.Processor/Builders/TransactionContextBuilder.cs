using Payment.Processor.Transaction.Context;
using Payment.Processor.Transaction.Model;

namespace Payment.Processor.Builders
{
    /// <summary>
    /// Describes the basic functionality of a transaction context builder.
    /// </summary>
    /// <typeparam name="TEnvelope">The type of the envelope contained in the transaction context.</typeparam>
    /// <typeparam name="TAttributes">The type of the processor attributes contained in the transaction context.</typeparam>
    public class TransactionContextBuilder<TEnvelope, TAttributes> : ITransactionContextBuilder<TEnvelope, TAttributes>
        where TEnvelope : IEnvelope
        where TAttributes : IProcessorAttributes
    {
        private readonly IBuilder<ActionContext> actionContextBuilder;
        private readonly ICardContextBuilder cardContextBuilder;
        private readonly ICardOnFileContextBuilder cardOnFileContextBuilder;
        private readonly IBuilder<TEnvelope> envelopeBuilder;
        private readonly IBuilder<ReaderContext> readerContextBuilder;

        /// <summary>
        /// Creates an instance of the transaction context type.
        /// </summary>
        /// <param name="actionContextBuilder">An action context builder.</param>
        /// <param name="cardContextBuilder">A card context builder.</param>
        /// <param name="cardOnFileContextBuilder">A card on file context builder.</param>
        /// <param name="envelopeBuilder">An envelope builder.</param>
        /// <param name="readerContextBuilder">A reader context builder.</param>
        public TransactionContextBuilder(IBuilder<ActionContext> actionContextBuilder,
            ICardContextBuilder cardContextBuilder,
            ICardOnFileContextBuilder cardOnFileContextBuilder,
            IBuilder<TEnvelope> envelopeBuilder,
            IBuilder<ReaderContext> readerContextBuilder)
        {
            this.actionContextBuilder = actionContextBuilder;
            this.cardContextBuilder = cardContextBuilder;
            this.cardOnFileContextBuilder = cardOnFileContextBuilder;
            this.envelopeBuilder = envelopeBuilder;
            this.readerContextBuilder = readerContextBuilder;
        }

        /// <summary>
        /// Builds a card on file context from a transaction and other associated contexts.
        /// </summary>
        /// <typeparam name="TTransactionContext">The type of the transaction context to build.</typeparam>
        /// <param name="transaction">A credit card payment transaction model.</param>
        /// <returns>An instance of the transaction context class.</returns>
        public async Task<TTransactionContext> BuildAsync<TTransactionContext>(ITransactionModel transaction)
            where TTransactionContext : ITransactionContext<TEnvelope, TAttributes>, new()
        {
            var actionContext = actionContextBuilder.Build(transaction);
            var cardContext = await cardContextBuilder.BuildAsync(transaction);
            var cardOnFileContext = cardOnFileContextBuilder.Build(transaction, actionContext);
            var envelope = envelopeBuilder.Build(transaction);
            var readerContext = readerContextBuilder.Build(transaction);

            return new TTransactionContext()
            {
                ActionContext = actionContext,
                CardContext = cardContext,
                CardOnFileContext = cardOnFileContext,
                Details = transaction.Details,
                Envelope = envelope,
                Merchant = transaction.Merchant,
                ProcessorAttributes = (TAttributes)transaction.ProcessorAttributes,
                ReaderContext = readerContext
            };
        }
    }
}
