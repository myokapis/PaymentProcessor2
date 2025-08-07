using Payment.Messages.Attributes.Format;

namespace Payment.Messages.Serializers.Formatters
{
    /// <summary>
    /// Describes behavior for a value formatter.
    /// </summary>
    public interface IFormatter
    {
        /// <summary>
        /// Formats a char value to a string.
        /// </summary>
        /// <param name="value">The value to be formatted.</param>
        /// <param name="formatter">The format attribute that controls how formatting occurs.</param>
        /// <returns>A formatted string representing the original value.</returns>
        string FormatValue(char value, IFormatAttribute? _formatAttribute);

        /// <summary>
        /// Formats a date/time value to a string.
        /// </summary>
        /// <param name="value">The value to be formatted.</param>
        /// <param name="formatter">The format attribute that controls how formatting occurs.</param>
        /// <returns>A formatted string representing the original value.</returns>
        string FormatValue(DateTime value, IFormatAttribute? formatAttribute);

        /// <summary>
        /// Formats a decimal value to a string.
        /// </summary>
        /// <param name="value">The value to be formatted.</param>
        /// <param name="formatter">The format attribute that controls how formatting occurs.</param>
        /// <returns>A formatted string representing the original value.</returns>
        string FormatValue(decimal value, IFormatAttribute? formatAttribute);

        /// <summary>
        /// Formats an integer value to a string.
        /// </summary>
        /// <param name="value">The value to be formatted.</param>
        /// <param name="formatter">The format attribute that controls how formatting occurs.</param>
        /// <returns>A formatted string representing the original value.</returns>
        string FormatValue(int value, IFormatAttribute? formatAttribute);

        /// <summary>
        /// Formats an object value to a string.
        /// </summary>
        /// <param name="value">The value to be formatted.</param>
        /// <param name="formatter">The format attribute that controls how formatting occurs.</param>
        /// <returns>A formatted string representing the original value.</returns>
        string FormatValue(object value, IFormatAttribute? formatAttribute);

        /// <summary>
        /// Formats a string value to a string.
        /// </summary>
        /// <param name="value">The value to be formatted.</param>
        /// <param name="formatter">The format attribute that controls how formatting occurs.</param>
        /// <returns>A formatted string representing the original value.</returns>
        string FormatValue(string value, IFormatAttribute? formatAttribute);

        /// <summary>
        /// Formats an unsigned integer value to a string.
        /// </summary>
        /// <param name="value">The value to be formatted.</param>
        /// <param name="formatter">The format attribute that controls how formatting occurs.</param>
        /// <returns>A formatted string representing the original value.</returns>
        string FormatValue(uint value, IFormatAttribute? formatAttribute);

        /// <summary>
        /// Formats an unsigned long value to a string.
        /// </summary>
        /// <param name="value">The value to be formatted.</param>
        /// <param name="formatter">The format attribute that controls how formatting occurs.</param>
        /// <returns>A formatted string representing the original value.</returns>
        string FormatValue(ulong value, IFormatAttribute? formatAttribute);
    }
}
