using System.Runtime.Serialization;

namespace Payment.Processor.Enums
{
    /// <summary>
    /// An enumeration of transaction results.
    /// </summary>
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
