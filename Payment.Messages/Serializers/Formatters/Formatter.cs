using System.Globalization;
using Payment.Messages.Attributes.Format;

namespace Payment.Messages.Serializers.Formatters
{
    // TODO: think about whether we should take culture into account.
    //       for now we'll use format strings with invariant culture.
    public class Formatter : IFormatter
    {
        public string FormatValue(char value, IFormatAttribute? _formatter)
        {
            return (value == default(char)) ? "" : value.ToString();
        }

        public string FormatValue(DateTime value, IFormatAttribute? formatter)
        {
            var workingFormatter = formatter ?? DefaultDateFormatter;
            return value.ToString(workingFormatter.FormatString, CultureInfo.InvariantCulture);
        }

        public string FormatValue(decimal value, IFormatAttribute? formatter)
        {
            var workingFormatter = formatter ?? DefaultDecimalFormatter;
            return value.ToString(workingFormatter.FormatString, CultureInfo.InvariantCulture);
        }

        public string FormatValue(int value, IFormatAttribute? formatter)
        {
            var workingFormatter = formatter ?? DefaultIntegerFormatter;
            return value.ToString(workingFormatter.FormatString, CultureInfo.InvariantCulture);
        }

        public string FormatValue(object value, IFormatAttribute? formatter)
        {
            switch(value)
            {
                case char:
                    return FormatValue((char)value, formatter);
                case DateTime:
                    return FormatValue((DateTime)value, formatter);
                case decimal:
                    return FormatValue((decimal)value, formatter);
                case int:
                    return FormatValue((int)value, formatter);
                case string:
                    return FormatValue((string)value, formatter);
                case uint:
                    return FormatValue((uint)value, formatter);
                case ulong:
                    return FormatValue((ulong)value, formatter);
                default:
                    return value.ToString() ?? "";
            }
        }

        public string FormatValue(string value, IFormatAttribute? formatter)
        {
            var workingFormatter = formatter ?? DefaultStringFormatter;

            if (workingFormatter.FormatString == string.Empty)
                return value;

            return string.Format(workingFormatter.FormatString, value);
        }

        public string FormatValue(uint value, IFormatAttribute? formatter)
        {
            var workingFormatter = formatter ?? DefaultIntegerFormatter;
            return value.ToString(workingFormatter.FormatString, CultureInfo.InvariantCulture);
        }

        public string FormatValue(ulong value, IFormatAttribute? formatter)
        {
            var workingFormatter = formatter ?? DefaultIntegerFormatter;
            return value.ToString(workingFormatter.FormatString, CultureInfo.InvariantCulture);
        }

        #region protected methods & properties

        protected static IFormatAttribute DefaultDateFormatter { get; } = new DateFormatAttribute();
        protected static IFormatAttribute DefaultDecimalFormatter { get; } = new DecimalFormatAttribute();
        protected static IFormatAttribute DefaultIntegerFormatter { get; } = new IntegerFormatAttribute();
        protected static IFormatAttribute DefaultStringFormatter { get; } = new StringFormatAttribute();

        #endregion
    }
}
