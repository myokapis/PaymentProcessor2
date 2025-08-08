using System.Runtime.Serialization;

namespace Payment.Processor.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Determines if the enum belongs to a set of enum values.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum being tested.</typeparam>
        /// <param name="value">The enum value to test for set membership.</param>
        /// <param name="valueSet">The set of enum values.</param>
        /// <returns>True if the enum value belongs to the set and false otherwise.</returns>
        public static bool OneOf<TEnum>(this TEnum value, params TEnum[] valueSet) where TEnum : struct
        {
            return valueSet.Any(m => m.Equals(value));
        }

        /// <summary>
        /// Parses a string to an enumerated value of the calling type.
        /// Defaults to the calling value when parsing fails.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="defaultValue">Value that is calling the extension method</param>
        /// <param name="value">String value to be parsed.</param>
        /// <returns>An enumerated value of the calling type</returns>
        public static TEnum Parse<TEnum>(this TEnum defaultValue, string? value) where TEnum : struct
        {
            if (Enum.TryParse<TEnum>(value, true, out var result))
                return result;

            var type = typeof(TEnum);
            var attributeType = typeof(EnumMemberAttribute);

            foreach (var field in type.GetFields())
            {
                var attribute = (EnumMemberAttribute?)field
                    .GetCustomAttributes(attributeType, false)
                    .FirstOrDefault();

                var attributeValue = attribute?.Value;
                if (attributeValue == null) continue;

                if (attributeValue.Equals(value, StringComparison.OrdinalIgnoreCase))
                    return (TEnum)field.GetValue(null)!;
            }
            
            return defaultValue;
        }
    }
}
