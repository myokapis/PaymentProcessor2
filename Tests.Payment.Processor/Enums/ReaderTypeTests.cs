using FluentAssertions;
using Payment.Processor.Enums;
using Payment.Processor.Extensions;

namespace Tests.Payment.Processor.Enums
{
    public class ReaderTypeTests
    {
        [Theory()]
        [MemberData(nameof(TestData))]
        public void ParsedValues(string inputValue, ReaderType expectedValue)
        {
            var parsedValue = ReaderType.UNKNOWN.Parse(inputValue);
            parsedValue.Should().Be(expectedValue);
        }

        public static IEnumerable<object?[]> TestData()
        {
            return new List<object?[]>()
            {
                new object?[] { null, ReaderType.UNKNOWN },
                new object?[] { "", ReaderType.UNKNOWN },
                new object?[] { "a250", ReaderType.A250 },
                new object?[] { "A250", ReaderType.A250 },
                new object?[] { "b200", ReaderType.B200 },
                new object?[] { "B200", ReaderType.B200 },
                new object?[] { "b250", ReaderType.B250 },
                new object?[] { "B250", ReaderType.B250 },
                new object?[] { "b350", ReaderType.B350 },
                new object?[] { "B350", ReaderType.B350 },
                new object?[] { "b500", ReaderType.B500 },
                new object?[] { "B500", ReaderType.B500 },
                new object?[] { "btmag", ReaderType.BTMAG },
                new object?[] { "BTMAG", ReaderType.BTMAG },
                new object?[] { "idtech", ReaderType.IDTECH },
                new object?[] { "IDTECH", ReaderType.IDTECH },
                new object?[] { "m010", ReaderType.M010 },
                new object?[] { "M010", ReaderType.M010 },
                new object?[] { "no_reader", ReaderType.NO_READER },
                new object?[] { "NO_READER", ReaderType.NO_READER },
                new object?[] { "rambler", ReaderType.RAMBLER },
                new object?[] { "RAMBLER", ReaderType.RAMBLER },
                new object?[] { "unencrypted", ReaderType.UNENCRYPTED },
                new object?[] { "UNENCRYPTED", ReaderType.UNENCRYPTED },
                new object?[] { "walker", ReaderType.WALKER },
                new object?[] { "WALKER", ReaderType.WALKER }
            };
        }
    }
}
