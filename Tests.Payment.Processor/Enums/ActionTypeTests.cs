using FluentAssertions;
using Payment.Processor.Enums;
using Payment.Processor.Extensions;

namespace Tests.Payment.Processor.Enums
{
    public class ActionTypeTests
    {
        [Theory()]
        [MemberData(nameof(TestData))]
        public void ParsedValues(string inputValue, ActionType expectedValue)
        {
            var parsedValue = ActionType.None.Parse(inputValue);
            parsedValue.Should().Be(expectedValue);
        }

        public static IEnumerable<object?[]> TestData()
        {
            return new List<object?[]>()
            {
                new object?[] { null, ActionType.None },
                new object?[] { "", ActionType.None },
                new object?[] { "auto_void", ActionType.AutoVoid },
                new object?[] { "AUTO_VOID", ActionType.AutoVoid },
                new object?[] { "balance_inquiry", ActionType.BalanceInquiry },
                new object?[] { "BALANCE_INQUIRY", ActionType.BalanceInquiry },
                new object?[] { "capture", ActionType.Capture },
                new object?[] { "CAPTURE", ActionType.Capture },
                new object?[] { "card_authentication", ActionType.CardAuth },
                new object?[] { "CARD_AUTHENTICATION", ActionType.CardAuth },
                new object?[] { "partial_reversal", ActionType.PartialReversal },
                new object?[] { "PARTIAL_REVERSAL", ActionType.PartialReversal },
                new object?[] { "pre_auth", ActionType.PreAuth },
                new object?[] { "PRE_AUTH", ActionType.PreAuth },
                new object?[] { "return", ActionType.Return },
                new object?[] { "RETURN", ActionType.Return },
                new object?[] { "sale", ActionType.Sale },
                new object?[] { "SALE", ActionType.Sale },
                new object?[] { "timeout_reversal", ActionType.TimeoutReversal },
                new object?[] { "TIMEOUT_REVERSAL", ActionType.TimeoutReversal },
                new object?[] { "void", ActionType.Void },
                new object?[] { "VOID", ActionType.Void }
            };
        }
    }
}
