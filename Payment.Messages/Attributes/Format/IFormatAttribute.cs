using Payment.Messages.Enums;

namespace Payment.Messages.Attributes.Format
{
    /// <summary>
    /// Defines an attribute to control data formatting.
    /// </summary>
    public interface IFormatAttribute
    {
        /// <summary>
        /// Gets or sets the format string to be used when formatting the field data.
        /// </summary>
        string FormatString { get; init; }

        /// <summary>
        /// Gets or sets the justification to be applied to the formatted field data.
        /// </summary>
        Justify Justify { get; init; }

        /// <summary>
        /// Gets or sets the maximum length of the formatted field data.
        /// </summary>
        int MaxLength { get; set; }

        /// <summary>
        /// Gets or sets the length to which the formatted field data should be padded.
        /// </summary>
        int PaddedLength { get; set; }

        /// <summary>
        /// Gets or sets the character to be used when padding the formatted field data.
        /// </summary>
        char PaddingChar { get; init; }
    }
}
