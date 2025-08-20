using Payment.Processor.Transaction.Context;
using Payment.Processor.Transaction.Model;

namespace Tests.Payment.Processor.TestHelpers
{
    public class TestTransactionContext : ITransactionContext<TestEnvelope, TestProcessorAttributes>
    {
#pragma warning disable CS8618
        public ActionContext ActionContext { get; init; }
        public CardContext CardContext { get; init; }
        public CardOnFileContext CardOnFileContext { get; init; }
        public Details Details { get; init; }
        public TestEnvelope? Envelope { get; init; }
        public Merchant Merchant { get; init; }
        public TestProcessorAttributes ProcessorAttributes { get; init; }
        public ReaderContext ReaderContext { get; init; }
#pragma warning restore CS8618
    }
}
