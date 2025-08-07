using Payment.Messages.Attributes.Format;
using Payment.Messages.Attributes.Serialization;

namespace Payment.Messages.Serializers
{
    /// <summary>
    /// A data transfer object for passing a field's value and metadata.
    /// </summary>
    public class FieldContent
    {
        /// <summary>
        /// The name of the field.
        /// </summary>
        public required string FieldName { get; init; }

        /// <summary>
        /// The format attribute attached to the field.
        /// </summary>
        public IFormatAttribute? FormatAttribute { get; init; }

        /// <summary>
        /// The serialization attribute attached to the field.
        /// </summary>
        public ISerializationAttribute? SerializationAttribute { get; init; }

        /// <summary>
        /// The field's data value.
        /// </summary>
        public object? Value { get; init; }
    }
}
