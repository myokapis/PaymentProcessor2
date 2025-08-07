using System.Reflection;
using Payment.Messages.Attributes.Format;
using Payment.Messages.Attributes.Serialization;

namespace Payment.Messages
{
    /// <summary>
    /// Metadata about a property on a class.
    /// </summary>
    public readonly struct FieldDefinition
    {
        /// <summary>
        /// The reflected property info for the property.
        /// </summary>
        public PropertyInfo PropertyInfo { get; init; }

        /// <summary>
        /// The format attribute attached to the property.
        /// </summary>
        public IFormatAttribute? FormatAttribute { get; init; }

        /// <summary>
        /// The serialization attribute attached to the property.
        /// </summary>
        public ISerializationAttribute? SerializationAttribute { get; init; }
    }
}
