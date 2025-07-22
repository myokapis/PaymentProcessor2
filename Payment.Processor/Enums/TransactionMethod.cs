using System.Runtime.Serialization;

namespace Payment.Processor.Enums
{
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
