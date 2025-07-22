using System.Runtime.Serialization;

namespace Payment.Processor.Enums
{
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
