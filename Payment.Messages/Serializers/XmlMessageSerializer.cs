using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Payment.Messages.Serializers.Formatters;

namespace Payment.Messages.Serializers
{
    public class XmlMessageSerializer : MessageSerializer, IXmlMessageSerializer
    {
        public XmlMessageSerializer(IFormatter formatter) : base(formatter) { }

        public override string SerializeMessage(IAccessibleMessage? message, bool isMasked = false)
        {
            if (message == null) return "";

            var xmlDocument = GetXmlDocument(message);

            // NOTE: the document will have a single node which is the XML for the top level message class.
            var messageNode = xmlDocument.FirstChild;
            if (messageNode == null) return "";

            ProcessNode(messageNode, message, isMasked);

            return XmlDocumentToString(xmlDocument);
        }

        public override void SerializeMessage(IAccessibleMessage? message, StringBuilder builder, bool isMasked = false)
        {
            if (message == null) return;

            builder.Append(SerializeMessage(message, isMasked));
        }

        protected virtual XmlDocument GetXmlDocument(IAccessibleMessage message)
        {
            var xmlDocument = new XmlDocument();
            var serializer = new XmlSerializer(message.GetType());
            var navigator = xmlDocument.CreateNavigator();

            if (navigator == null)
                throw new NullReferenceException("Unable to create an XML document.");

            using (var xmlWriter = navigator.AppendChild())
            {
                serializer.Serialize(xmlWriter, message);
            }

            return xmlDocument;
        }

        protected virtual void ProcessNode(XmlNode xmlNode, IAccessibleMessage message, bool isMasked)
        {
            var nodeIndex = 0;

            foreach (var fieldDefinition in message.FieldDefinitions)
            {
                FieldContent fieldContent = ExtractContent(message, fieldDefinition);
                var childNode = xmlNode.ChildNodes[nodeIndex];
                nodeIndex++;

                if (childNode == null) continue;

                if (fieldContent.Value is IAccessibleMessage)
                {
                    ProcessNode(childNode, (IAccessibleMessage)fieldContent.Value, isMasked);
                }
                else
                {
                    if (childNode.InnerText == null) continue;

                    // TODO: handle collections of values
                    var fieldValue = FormatField(fieldContent, isMasked);

                    if (childNode.InnerText != fieldValue)
                        childNode.InnerText = fieldValue;
                }
            }
        }

        protected virtual string XmlDocumentToString(XmlDocument xmlDocument)
        {
            using (var writer = new StringWriter())
            {
                using(var xmlWriter = XmlWriter.Create(writer))
                {
                    xmlDocument.WriteTo(xmlWriter);
                }

                return writer.ToString();
            }
        }
    }
}
