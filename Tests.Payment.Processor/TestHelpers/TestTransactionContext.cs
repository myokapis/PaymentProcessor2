using Payment.Processor.Transaction.Context;
using Payment.Processor.Transaction.Model;

namespace Tests.Payment.Processor.TestHelpers
{
    public class TestTransactionContext : ITransactionContext<TestEnvelope, TestProcessorAttributes>
    {
#pragma warning disable CS8618
        public ActionContext ActionContext { get; set; }
        public CardContext CardContext { get; set; }
        public CardOnFileContext CardOnFileContext { get; set; }
        public Details Details { get; set; }
        public TestEnvelope? Envelope { get; set; }
        public Merchant Merchant { get; set; }
        public TestProcessorAttributes ProcessorAttributes { get; set; }
        public ReaderContext ReaderContext { get; set; }
#pragma warning restore CS8618
    }
}
