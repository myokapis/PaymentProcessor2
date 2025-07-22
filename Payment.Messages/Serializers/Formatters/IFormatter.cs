using Payment.Messages.Attributes.Format;

namespace Payment.Messages.Serializers.Formatters
{
    public interface IFormatter
    {
        string FormatValue(DateTime value, IFormatAttribute? formatter);
        string FormatValue(decimal value, IFormatAttribute? formatter);
        string FormatValue(int value, IFormatAttribute? formatter);
        string FormatValue(object value, IFormatAttribute? _formatter);
        string FormatValue(string value, IFormatAttribute? formatter);
        string FormatValue(uint value, IFormatAttribute? formatter);
        string FormatValue(ulong value, IFormatAttribute? formatter);
    }
}
