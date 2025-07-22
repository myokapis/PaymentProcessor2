using Payment.Messages.Enums;

namespace Payment.Messages.Attributes.Format
{
    public class DecimalFormatAttribute : FormatAttribute
    {
        public DecimalFormatAttribute() : base()
        { }

        public override string FormatString { get; init; } = "g";
        public override Justify Justify { get; init; } = Justify.Right;
        public override char PaddingChar { get; init; } = '0';
    }
}
