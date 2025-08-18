using Payment.Processor.Transaction.Context;

namespace Tests.Payment.Processor.TestHelpers
{
    public class TestEnvelope : IEnvelope
    {
        public bool Empty { get; set; }
    }
}
