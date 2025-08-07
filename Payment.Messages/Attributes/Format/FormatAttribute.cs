using System.Globalization;
using Payment.Messages.Enums;

namespace Payment.Messages.Attributes.Format
{
    /// <summary>
    /// An abstract class on which field formatting attributes can be based.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public abstract class FormatAttribute : Attribute, IFormatAttribute
    {
        /// <summary>
        /// Constructs an instance of the formatter.
        /// </summary>
        public FormatAttribute() {}

        /// <summary>
        /// Gets or sets the format string to be used when formatting the field data.
        /// </summary>
        public virtual string FormatString { get; init; } = string.Empty;

        /// <summary>
        /// Gets or sets the justification to be applied to the formatted field data.
        /// </summary>
        public virtual Justify Justify { get; init; } = Justify.Left;

        /// <summary>
        /// Gets or sets the maximum length of the formatted field data.
        /// </summary>
        public virtual int MaxLength { get; set; } = 0;

        /// <summary>
        /// Gets or sets the length to which the formatted field data should be padded.
        /// </summary>
        public virtual int PaddedLength { get; set; } = 0;

        /// <summary>
        /// Gets or sets the character to be used when padding the formatted field data.
        /// </summary>
        public virtual char PaddingChar { get; init; } = ' ';
    }
}
