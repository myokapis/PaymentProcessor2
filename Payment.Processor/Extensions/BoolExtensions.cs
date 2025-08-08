using System.Runtime.CompilerServices;

namespace Payment.Processor.Extensions
{
    /// <summary>
    /// Extensions to tbe boolean class.
    /// </summary>
    public static class BoolExtensions
    {
        /// <summary>
        /// Parses a nullable string value into a boolean. Invalid parsing yields the default value.
        /// </summary>
        /// <param name="defaultValue">The value to return if parsing fails.</param>
        /// <param name="value">The value to be parsed.</param>
        /// <returns>The boolean value associated with the original string value.</returns>
        public static bool Parse(this bool defaultValue, string? value)
        {
            if (!bool.TryParse(value, out var result))
                return defaultValue;

            return result;
        }
    }
}
