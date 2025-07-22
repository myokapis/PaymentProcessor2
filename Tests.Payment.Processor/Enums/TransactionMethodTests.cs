using FluentAssertions;
using Payment.Processor.Enums;
using Payment.Processor.Extensions;

namespace Tests.Payment.Processor.Enums
{
    public class TransactionMethodTests
    {
        [Theory()]
        [MemberData(nameof(TestData))]
        public void ParsedValues(string inputValue, TransactionMethod expectedValue)
        {
            var parsedValue = TransactionMethod.Unknown.Parse(inputValue);
            parsedValue.Should().Be(expectedValue);
        }

        public static IEnumerable<object?[]> TestData()
        {
            return new List<object?[]>()
            {
                new object?[] { null, TransactionMethod.Unknown },
                new object?[] { "", TransactionMethod.Unknown },
                new object?[] { "dipped", TransactionMethod.Dipped },
                new object?[] { "DIPPED", TransactionMethod.Dipped },
                new object?[] { "keyed", TransactionMethod.Keyed },
                new object?[] { "KEYED", TransactionMethod.Keyed },
                new object?[] { "qc_dipped", TransactionMethod.QuickChip },
                new object?[] { "QC_DIPPED", TransactionMethod.QuickChip },
                new object?[] { "swiped", TransactionMethod.Swiped },
                new object?[] { "SWIPED", TransactionMethod.Swiped },
                new object?[] { "swiped_fallback", TransactionMethod.SwipedFallback },
                new object?[] { "SWIPED_FALLBACK", TransactionMethod.SwipedFallback },
                new object?[] { "tapped", TransactionMethod.Tapped },
                new object?[] { "TAPPED", TransactionMethod.Tapped },
                new object?[] { "token", TransactionMethod.Token },
                new object?[] { "TOKEN", TransactionMethod.Token }
            };
        }
    }
}
