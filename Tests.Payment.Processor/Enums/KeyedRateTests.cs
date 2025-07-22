using FluentAssertions;
using Payment.Processor.Enums;
using Payment.Processor.Extensions;

namespace Tests.Payment.Processor.Enums
{
    public class KeyedRateTests
    {
        [Theory()]
        [MemberData(nameof(TestData))]
        public void ParsedValues(string inputValue, KeyedRate expectedValue)
        {
            var parsedValue = KeyedRate.Any.Parse(inputValue);
            parsedValue.Should().Be(expectedValue);
        }

        public static IEnumerable<object?[]> TestData()
        {
            return new List<object?[]>()
            {
                new object?[] { null, KeyedRate.Any },
                new object?[] { "", KeyedRate.Any },
                new object?[] { "moto", KeyedRate.MOTO },
                new object?[] { "MOTO", KeyedRate.MOTO },
                new object?[] { "retail", KeyedRate.Retail },
                new object?[] { "RETAIL", KeyedRate.Retail }
            };
        }
    }
}
