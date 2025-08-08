using System.Runtime.Serialization;

namespace Payment.Processor.Enums
{
    /// <summary>
    /// An enumeration of card brands.
    /// </summary>
    public enum CardBrand
    {
        Unknown,
        Amex,

        [EnumMember(Value = "DINERS_CLUB")]
        DinersClub,

        Discover,
        JCB,

        [EnumMember(Value = "MASTER_CARD")]
        MasterCard,

        [EnumMember(Value = "UNION_PAY")]
        UnionPay,

        Visa
    }
}
