using System.Text;
using Payment.Messages.Serializers.Formatters;

namespace Payment.Messages.Serializers
{
    public class StringMessageSerializer : MessageSerializer, IStringMessageSerializer
    {

        public StringMessageSerializer(IFormatter formatter) : base(formatter) { }

        public override string SerializeMessage(IAccessibleMessage? message, bool isMasked = false)
        {
            if (message == null) return "";

            var builder = new StringBuilder();
            SerializeMessage(message, builder, isMasked);
            return builder.ToString();
        }

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
