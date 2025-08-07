using Payment.Messages.Enums;

namespace Payment.Messages.Attributes.Format
{
    /// <summary>
    /// Defines an attribute to control data formatting of a decimal.
    /// </summary>
    public class DecimalFormatAttribute : FormatAttribute
    {
        /// <summary>
        /// Constructs an instance of the format attribute.
        /// </summary>
        public DecimalFormatAttribute() : base()
        { }

        /// <summary>
        /// Gets or sets the format string to be used when formatting the field data.
        /// </summary>
        public override string FormatString { get; init; } = "g";

        /// <summary>
        /// Gets or sets the justification to be applied to the formatted field data.
        /// </summary>
        public override Justify Justify { get; init; } = Justify.Right;

        /// <summary>
        /// Gets or sets the character to be used when padding the formatted field data.
        /// </summary>
        public override char PaddingChar { get; init; } = '0';
    }
}
