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

        //[EnumMember(Value = "Capture")]
        Capture,

        [EnumMember(Value = "Card_Authentication")]
        CardAuth,

        [EnumMember(Value = "Partial_Reversal")]
        PartialReversal,

        [EnumMember(Value = "Pre_Auth")]
        PreAuth,

        //[EnumMember(Value = "Return")]
        Return,

        //[EnumMember(Value = "Sale")]
        Sale,

        [EnumMember(Value = "Timeout_Reversal")]
        TimeoutReversal,

        //[EnumMember(Value = "Void")]
        Void
    }
}
