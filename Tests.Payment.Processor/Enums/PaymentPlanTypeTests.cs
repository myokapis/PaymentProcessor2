using FluentAssertions;
using Payment.Processor.Enums;
using Payment.Processor.Extensions;

namespace Tests.Payment.Processor.Enums
{
    public class PaymentPlanTypeTests
    {
        [Theory()]
        [MemberData(nameof(TestData))]
        public void ParsedValues(string inputValue, PaymentPlanType expectedValue)
        {
            var parsedValue = PaymentPlanType.None.Parse(inputValue);
            parsedValue.Should().Be(expectedValue);
        }

        public static IEnumerable<object?[]> TestData()
        {
            return new List<object?[]>()
            {
                new object?[] { null, PaymentPlanType.None },
                new object?[] { "", PaymentPlanType.None },
                new object?[] { "installment", PaymentPlanType.Installment },
                new object?[] { "INSTALLMENT", PaymentPlanType.Installment },
                new object?[] { "recurring", PaymentPlanType.Recurring },
                new object?[] { "RECURRING", PaymentPlanType.Recurring },
                new object?[] { "single", PaymentPlanType.Single },
                new object?[] { "SINGLE", PaymentPlanType.Single }
            };
        }
    }
}
