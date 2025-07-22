using FluentAssertions;
using Payment.Processor.Enums;
using Payment.Processor.Extensions;

namespace Tests.Payment.Processor.Enums
{
    public class PlatformTests
    {
        [Theory()]
        [MemberData(nameof(TestData))]
        public void ParsedValues(string inputValue, Platform expectedValue)
        {
            var parsedValue = Platform.Unknown.Parse(inputValue);
            parsedValue.Should().Be(expectedValue);
        }

        public static IEnumerable<object?[]> TestData()
        {
            return new List<object?[]>()
            {
                new object?[] { null, Platform.Unknown },
                new object?[] { "", Platform.Unknown },
                new object?[] { "android", Platform.Android },
                new object?[] { "ANDROID", Platform.Android },
                new object?[] { "ios", Platform.iOS },
                new object?[] { "IOS", Platform.iOS },
                new object?[] { "scheduled_payment", Platform.ScheduledPayment },
                new object?[] { "SCHEDULED_PAYMENT", Platform.ScheduledPayment },
                new object?[] { "terminal", Platform.Terminal },
                new object?[] { "TERMINAL", Platform.Terminal },
                new object?[] { "virtual_terminal", Platform.VirtualTerminal },
                new object?[] { "VIRTUAL_TERMINAL", Platform.VirtualTerminal }
            };
        }
    }
}
