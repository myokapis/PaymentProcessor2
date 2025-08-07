using System.Globalization;
using Payment.Messages.Attributes.Format;

namespace Payment.Messages.Serializers.Formatters
{
    // TODO: think about whether we should take culture into account.
    //       for now we'll use format strings with invariant culture.
    public class Formatter : IFormatter
    {
        /// <summary>
        /// Formats a char value to a string.
        /// </summary>
        /// <param name="value">The value to be formatted.</param>
        /// <param name="formatter">The format attribute that controls how formatting occurs.</param>
        /// <returns>A formatted string representing the original value.</returns>
        public string FormatValue(char value, IFormatAttribute? _formatAttribute)
        {
            return (value == default(char)) ? "" : value.ToString();
        }

        /// <summary>
        /// Formats a date/time value to a string.
        /// </summary>
        /// <param name="value">The value to be formatted.</param>
        /// <param name="formatter">The format attribute that controls how formatting occurs.</param>
        /// <returns>A formatted string representing the original value.</returns>
        public string FormatValue(DateTime value, IFormatAttribute? formatAttribute)
        {
            var workingFormatter = formatAttribute ?? DefaultDateFormatAttribute;
            return value.ToString(workingFormatter.FormatString, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Formats a decimal value to a string.
        /// </summary>
        /// <param name="value">The value to be formatted.</param>
        /// <param name="formatter">The format attribute that controls how formatting occurs.</param>
        /// <returns>A formatted string representing the original value.</returns>
        public string FormatValue(decimal value, IFormatAttribute? formatAttribute)
        {
            var workingFormatter = formatAttribute ?? DefaultDecimalFormatAttribute;
            return value.ToString(workingFormatter.FormatString, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Formats an integer value to a string.
        /// </summary>
        /// <param name="value">The value to be formatted.</param>
        /// <param name="formatter">The format attribute that controls how formatting occurs.</param>
        /// <returns>A formatted string representing the original value.</returns>
        public string FormatValue(int value, IFormatAttribute? formatAttribute)
        {
            var workingFormatter = formatAttribute ?? DefaultIntegerFormatAttribute;
            return value.ToString(workingFormatter.FormatString, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Formats an object value to a string. The appropriate formatter is selected based on the
        /// object type.
        /// </summary>
        /// <param name="value">The value to be formatted.</param>
        /// <param name="formatter">The format attribute that controls how formatting occurs.</param>
        /// <returns>A formatted string representing the original value.</returns>
        public string FormatValue(object value, IFormatAttribute? formatAttribute)
        {
            switch(value)
            {
                case char:
                    return FormatValue((char)value, formatAttribute);
                case DateTime:
                    return FormatValue((DateTime)value, formatAttribute);
                case decimal:
                    return FormatValue((decimal)value, formatAttribute);
                case int:
                    return FormatValue((int)value, formatAttribute);
                case string:
                    return FormatValue((string)value, formatAttribute);
                case uint:
                    return FormatValue((uint)value, formatAttribute);
                case ulong:
                    return FormatValue((ulong)value, formatAttribute);
                default:
                    return value.ToString() ?? "";
            }
        }

        /// <summary>
        /// Formats an object value to a string.
        /// </summary>
        /// <param name="value">The value to be formatted.</param>
        /// <param name="formatter">The format attribute that controls how formatting occurs.</param>
        /// <returns>A formatted string representing the original value.</returns>
        public string FormatValue(string value, IFormatAttribute? formatAttribute)
        {
            var workingFormatter = formatAttribute ?? DefaultStringFormatAttribute;

            if (workingFormatter.FormatString == string.Empty)
                return value;

            return string.Format(workingFormatter.FormatString, value);
        }

        /// <summary>
        /// Formats an unsigned integer value to a string.
        /// </summary>
        /// <param name="value">The value to be formatted.</param>
        /// <param name="formatter">The format attribute that controls how formatting occurs.</param>
        /// <returns>A formatted string representing the original value.</returns>
        public string FormatValue(uint value, IFormatAttribute? formatAttribute)
        {
            var workingFormatter = formatAttribute ?? DefaultIntegerFormatAttribute;
            return value.ToString(workingFormatter.FormatString, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Formats an unsigned long value to a string.
        /// </summary>
        /// <param name="value">The value to be formatted.</param>
        /// <param name="formatter">The format attribute that controls how formatting occurs.</param>
        /// <returns>A formatted string representing the original value.</returns>
        public string FormatValue(ulong value, IFormatAttribute? formatAttribute)
        {
            var workingFormatter = formatAttribute ?? DefaultIntegerFormatAttribute;
            return value.ToString(workingFormatter.FormatString, CultureInfo.InvariantCulture);
        }

        #region protected methods & properties

        protected static IFormatAttribute DefaultDateFormatAttribute { get; } = new DateFormatAttribute();
        protected static IFormatAttribute DefaultDecimalFormatAttribute { get; } = new DecimalFormatAttribute();
        protected static IFormatAttribute DefaultIntegerFormatAttribute { get; } = new IntegerFormatAttribute();
        protected static IFormatAttribute DefaultStringFormatAttribute { get; } = new StringFormatAttribute();

        #endregion
    }
}
