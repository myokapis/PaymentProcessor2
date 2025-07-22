using Payment.Messages;
using Payment.Messages.Attributes.Serialization;

namespace Tests.Payment.Messages.Helpers
{
    public class TestParentMessage : AccessibleMessage<TestParentMessage>
    {
        //[Serialization(Terminator = "")]
        public string? Field1 { get; set; }

        public int Field2 { get; set; }
        public DateTime Field3 { get; set; }
        public TestChildMessage? Field4 { get; set; }
        public string? Field5 { get; set; }
    }
}
