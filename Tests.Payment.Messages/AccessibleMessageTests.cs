using FluentAssertions;
using Tests.Payment.Messages.Helpers;

namespace Tests.Payment.Messages
{
    public class AccessibleMessageTests
    {
        [Fact]
        public void FieldCount()
        {
            var message = new TestChildMessage();
            message.FieldCount.Should().Be(3);
        }
    }
}
