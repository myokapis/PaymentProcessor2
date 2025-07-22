using System.Reflection;
using Payment.Messages.Attributes.Format;
using Payment.Messages.Attributes.Serialization;

namespace Payment.Messages
{
    public readonly struct FieldDefinition
    {
        public PropertyInfo PropertyInfo { get; init; }
        public IFormatAttribute? FormatAttribute { get; init; }
        public ISerializationAttribute? SerializationAttribute { get; init; }
    }
}
