using FluentAssertions;
using Payment.Processor.Enums;
using Payment.Processor.Extensions;

namespace Tests.Payment.Processor.Extensions
{
    public class BoolExtensionsTests
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void Parse(string? inputValue, bool expectedValue)
        {
            var parsedValue = false.Parse(inputValue);
            parsedValue.Should().Be(expectedValue);
        }

        public static IEnumerable<object?[]> TestData()
        {
            return new List<object?[]>()
            {
                new object?[] { null, false },
                new object?[] { "", false },
                new object?[] { "false", false },
                new object?[] { "False", false },
                new object?[] { "F", false },
                new object?[] { "0", false },
                new object?[] { "true", true },
                new object?[] { "True", true },
                new object?[] { "T", false },
                new object?[] { "1", false },
            };
        }
    }
}
