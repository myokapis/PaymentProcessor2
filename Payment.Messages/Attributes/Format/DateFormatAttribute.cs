using Payment.Messages.Enums;

namespace Payment.Messages.Attributes.Format
{
    /// <summary>
    /// Defines an attribute to control data formatting of a date/time.
    /// </summary>
    public class DateFormatAttribute : FormatAttribute
    {
        /// <summary>
        /// Constructs an instance of the format attribute.
        /// </summary>
        public DateFormatAttribute() : base()
        { }

        /// <summary>
        /// Gets or sets the format string to be used when formatting the field data.
        /// </summary>
        public override string FormatString { get; init; } = "s";

        /// <summary>
        /// Gets or sets the justification to be applied to the formatted field data.
        /// </summary>
        public override Justify Justify { get; init; } = Justify.None;

        /// <summary>
        /// Gets or sets the character to be used when padding the formatted field data.
        /// </summary>
        public override char PaddingChar { get; init; } = ' ';
    }
}
