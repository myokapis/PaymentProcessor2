using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Payment.Messages.Serializers.Formatters;

namespace Payment.Messages.Serializers
{
    /// <summary>
    /// Implements basic functionality for serializing a message to a JSON string.
    /// </summary>
    public class JsonMessageSerializer : MessageSerializer, IJsonMessageSerializer
    {
        /// <summary>
        /// Constructs and instance of the JSON message serializer.
        /// </summary>
        /// <param name="formatter">The formatter to be used when preparing the message data.</param>
        public JsonMessageSerializer(IFormatter formatter) : base(formatter) { }

        /// <summary>
        /// Serializes an accessible message to a JSON string.
        /// </summary>
        /// <param name="message">The message to be serialized.</param>
        /// <param name="isMasked">Turns masking of sensitive data on and off.</param>
        /// <returns>A JSON string representing the original message.</returns>
        public override string SerializeMessage(IAccessibleMessage? message, bool isMasked = false)
        {
            if (message == null) return "";

            var jsonNode = JsonSerializer.SerializeToNode(message, message.GetType());
            if (jsonNode == null) return "";

            ProcessNode(jsonNode, message, isMasked);

            return JsonNodeToString(jsonNode);
        }

        /// <summary>
        /// Serializes an accessible message to a JSON string.
        /// </summary>
        /// <param name="message">The message to be serialized.</param>
        /// <param name="builder">A string builder into which the serialized message is written.</param>
        /// <param name="isMasked">Turns masking of sensitive data on and off.</param>
        public override void SerializeMessage(IAccessibleMessage? message, StringBuilder builder, bool isMasked = false)
        {
            if (message == null) return;

            builder.Append(SerializeMessage(message, isMasked));
        }

        protected string JsonNodeToString(JsonNode jsonNode) => jsonNode.ToJsonString();

        protected void ProcessNode(JsonNode jsonNode, IAccessibleMessage message, bool isMasked)
        {
            var nodeIndex = 0;

            foreach (var fieldDefinition in message.FieldDefinitions)
            {
                FieldContent fieldContent = ExtractContent(message, fieldDefinition);
                var childNode = jsonNode[nodeIndex];
                nodeIndex++;

                if (childNode == null) continue;

                if (fieldContent.Value is IAccessibleMessage)
                {
                    ProcessNode(childNode, (IAccessibleMessage)fieldContent.Value, isMasked);
                }
                else
                {
                    if (childNode == null) continue;

                    // TODO: handle collections of values in the formatter
                    var fieldValue = FormatField(fieldContent, isMasked);

                    if (childNode.ToString() != fieldValue)
                        jsonNode[nodeIndex - 1] = fieldValue;
                }
            }
        }
    }
}
