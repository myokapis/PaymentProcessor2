using FluentAssertions;
using Payment.Processor.Enums;
using Payment.Processor.Extensions;

namespace Tests.Payment.Processor.Enums
{
    public class TransactionResultTests
    {
        [Theory()]
        [MemberData(nameof(TestData))]
        public void ParsedValues(string inputValue, TransactionResult expectedValue)
        {
            var parsedValue = TransactionResult.ProcessingError.Parse(inputValue);
            parsedValue.Should().Be(expectedValue);
        }

        public static IEnumerable<object?[]> TestData()
        {
            return new List<object?[]>()
            {
                new object?[] { null, TransactionResult.ProcessingError },
                new object?[] { "", TransactionResult.ProcessingError },
                new object?[] { "approved", TransactionResult.Approved },
                new object?[] { "APPROVED", TransactionResult.Approved },
                new object?[] { "not_approved", TransactionResult.NotApproved },
                new object?[] { "NOT_APPROVED", TransactionResult.NotApproved },
                new object?[] { "processing_error", TransactionResult.ProcessingError },
                new object?[] { "PROCESSING_ERROR", TransactionResult.ProcessingError },
                new object?[] { "retryable", TransactionResult.Retryable },
                new object?[] { "RETRYABLE", TransactionResult.Retryable },
                new object?[] { "unknown_error", TransactionResult.UnknownError },
                new object?[] { "UNKNOWN_ERROR", TransactionResult.UnknownError },
            };
        }
    }
}
