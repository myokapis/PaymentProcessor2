using System.Runtime.Serialization;

namespace Payment.Processor.Enums
{
    /// <summary>
    /// An enumeration of payment processing actions.
    /// </summary>
    public enum ActionType
    {
        None,

        [EnumMember(Value = "auto_void")]
        AutoVoid,

        [EnumMember(Value = "Balance_Inquiry")]
        BalanceInquiry,

        Capture,

        [EnumMember(Value = "Card_Authentication")]
        CardAuth,

        [EnumMember(Value = "Partial_Reversal")]
        PartialReversal,

        [EnumMember(Value = "Pre_Auth")]
        PreAuth,

        Return,

        Sale,

        [EnumMember(Value = "Timeout_Reversal")]
        TimeoutReversal,

        Void
    }
}
