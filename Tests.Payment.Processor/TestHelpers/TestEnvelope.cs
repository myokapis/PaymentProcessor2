using Payment.Processor.Transaction.Context.V1;

namespace Tests.Payment.Processor.TestHelpers
{
    public class TestEnvelope : IEnvelope
    {
        public bool Empty { get; set; }
    }
}
