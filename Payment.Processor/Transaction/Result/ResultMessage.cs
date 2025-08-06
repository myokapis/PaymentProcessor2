using Payment.Processor.Enums;

namespace Payment.Processor.Transaction.Result
{
    // TODO: finish this and also make sure the enum serializes correctly
    public class ResultMessage
    {
        public string? AuthCode { get; init; }
        public required TransactionResult Result { get; init; }
    }
}
