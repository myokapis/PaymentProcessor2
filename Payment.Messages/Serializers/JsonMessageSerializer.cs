using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Payment.Messages.Serializers.Formatters;

namespace Payment.Messages.Serializers
{
    public class JsonMessageSerializer : MessageSerializer, IJsonMessageSerializer
    {
        public JsonMessageSerializer(IFormatter formatter) : base(formatter) { }

        public override string SerializeMessage(IAccessibleMessage? message, bool isMasked = false)
        {
            if (message == null) return "";

            var jsonNode = JsonSerializer.SerializeToNode(message, message.GetType());
            if (jsonNode == null) return "";

            ProcessNode(jsonNode, message, isMasked);

            return JsonNodeToString(jsonNode);
        }

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
