using System.Runtime.Serialization;

namespace Payment.Processor.Enums
{
    public enum TransactionResult
    {
        [EnumMember(Value = "APPROVED")]
        Approved,

        [EnumMember(Value = "NOT_APPROVED")]
        NotApproved,

        [EnumMember(Value = "PROCESSING_ERROR")]
        ProcessingError,

        [EnumMember(Value = "RETRYABLE")]
        Retryable,

        [EnumMember(Value = "UNKNOWN_ERROR")]
        UnknownError
    }
}
