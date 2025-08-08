using System.Runtime.Serialization;

namespace Payment.Processor.Enums
{
    /// <summary>
    /// An enumeration of credit card transaction methods.
    /// </summary>
    public enum TransactionMethod
    {
        Unknown,
        Dipped,
        Keyed,

        [EnumMember(Value = "QC_DIPPED")]
        QuickChip,

        Swiped,

        [EnumMember(Value = "SWIPED_FALLBACK")]
        SwipedFallback,

        Tapped,
        Token
    }
}
