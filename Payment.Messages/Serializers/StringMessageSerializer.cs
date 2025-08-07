using System.Text;
using Payment.Messages.Serializers.Formatters;

namespace Payment.Messages.Serializers
{
    public class StringMessageSerializer : MessageSerializer, IStringMessageSerializer
    {
        /// <summary>
        /// Constructs and instance of the string message serializer.
        /// </summary>
        /// <param name="formatter">The formatter to be used when preparing the message data.</param>
        public StringMessageSerializer(IFormatter formatter) : base(formatter) { }

        /// <summary>
        /// Serializes an accessible message to a string.
        /// </summary>
        /// <param name="message">The message to be serialized.</param>
        /// <param name="isMasked">Turns masking of sensitive data on and off.</param>
        /// <returns>A string representing the original message.</returns>
        public override string SerializeMessage(IAccessibleMessage? message, bool isMasked = false)
        {
            if (message == null) return "";

            var builder = new StringBuilder();
            SerializeMessage(message, builder, isMasked);
            return builder.ToString();
        }

        /// <summary>
        /// Serializes an accessible message to a string.
        /// </summary>
        /// <param name="message">The message to be serialized.</param>
        /// <param name="builder">A string builder into which the serialized message is written.</param>
        /// <param name="isMasked">Turns masking of sensitive data on and off.</param>
        public override void SerializeMessage(IAccessibleMessage? message, StringBuilder builder, bool isMasked = false)
        {
            if (message == null) return;

            foreach (var fieldDefinition in message.FieldDefinitions)
            {
                FieldContent fieldContent = ExtractContent(message, fieldDefinition);
                int messageLength = builder.Length;

                if (fieldContent.Value is IAccessibleMessage)
                {
                    SerializeMessage((IAccessibleMessage)fieldContent.Value, builder);
                }
                else
                {
                    // TODO: handle collections of values
                    var fieldValue = FormatField(fieldContent, isMasked);
                    builder.Append(fieldValue);
                }

                var terminator = fieldDefinition.SerializationAttribute?.Terminator;
                var terminate = (fieldDefinition.SerializationAttribute?.AlwaysTerminate ?? false) || 
                    builder.Length > messageLength;

                if (terminator != null && terminate) builder.Append(terminator);
            }
        }
    }
}
