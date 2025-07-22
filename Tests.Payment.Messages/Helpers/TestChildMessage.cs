using Payment.Messages;

namespace Tests.Payment.Messages.Helpers
{
    public class TestChildMessage : AccessibleMessage<TestChildMessage>
    {
        public int Field1 { get; set; }
        public string? Field2 { get; set; }
        public string? Field3 { get; set; }
    }
}
