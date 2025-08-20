using Payment.Processor.Builders.V1;
using Payment.Processor.Transaction.Context.V1;
using TsysProcessor.Transaction.Model;

namespace TsysProcessor.Transaction.Context
{
    public class TsysTransactionContextBuilder : TransactionContextBuilder<TsysEnvelope, TsysProcessorAttributes> // IBuilderAsync<TsysTransactionContext>
    {
        public TsysTransactionContextBuilder(IBuilder<ActionContext> actionContextBuilder,
            ICardContextBuilder cardContextBuilder,
            ICardOnFileContextBuilder cardOnFileContextBuilder,
            IBuilder<TsysEnvelope> envelopeBuilder,
            IBuilder<ReaderContext> readerContextBuilder) :
            base(actionContextBuilder, cardContextBuilder, cardOnFileContextBuilder, envelopeBuilder, readerContextBuilder)
        {}
    }
}
