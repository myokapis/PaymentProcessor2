using FluentAssertions;
using Payment.Processor.Enums;
using Payment.Processor.Extensions;

namespace Tests.Payment.Processor.Enums
{
    public class DataSourceTests
    {
        [Theory()]
        [MemberData(nameof(TestData))]
        public void ParsedValues(string inputValue, DataSource expectedValue)
        {
            var parsedValue = DataSource.Unknown.Parse(inputValue);
            parsedValue.Should().Be(expectedValue);
        }

        public static IEnumerable<object?[]> TestData()
        {
            return new List<object?[]>()
            {
                new object?[] { null, DataSource.Unknown },
                new object?[] { "", DataSource.Unknown },
                new object?[] { "application", DataSource.Application },
                new object?[] { "APPLICATION", DataSource.Application },
                new object?[] { "mobile_device", DataSource.MobileDevice },
                new object?[] { "MOBILE_DEVICE", DataSource.MobileDevice },
                new object?[] { "reader", DataSource.Reader },
                new object?[] { "READER", DataSource.Reader }
            };
        }
    }
}
