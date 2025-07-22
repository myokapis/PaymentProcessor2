using System.Globalization;
using Payment.Messages.Enums;

namespace Payment.Messages.Attributes.Format
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public abstract class FormatAttribute : Attribute, IFormatAttribute
    {
        public FormatAttribute() {}

        public virtual string FormatString { get; init; } = string.Empty;
        public virtual Justify Justify { get; init; } = Justify.Left;
        public virtual int MaxLength { get; set; } = 0;
        public virtual int PaddedLength { get; set; } = 0;
        public virtual char PaddingChar { get; init; } = ' ';
    }
}
