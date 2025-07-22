using Payment.Messages.Attributes.Format;
using Payment.Messages.Attributes.Serialization;

namespace Payment.Messages.Serializers
{
    public class FieldContent
    {
        public required string FieldName { get; init; }
        public IFormatAttribute? FormatAttribute { get; init; }
        public ISerializationAttribute? SerializationAttribute { get; init; }
        public object? Value { get; init; }
    }
}
