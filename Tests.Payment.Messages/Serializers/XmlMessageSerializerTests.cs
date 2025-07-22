using System.Text;
using System.Xml;
using System.Xml.Serialization;
using FluentAssertions;
using Payment.Messages;
using Payment.Messages.Serializers;
using Payment.Messages.Serializers.Formatters;
using Tests.Payment.Messages.Helpers;

namespace Tests.Payment.Messages.Serializers
{
    public class XmlMessageSerializerTests
    {
        [Fact]
        public void SerializeMessage()
        {
            var message = new TestParentMessage()
            {
                Field1 = "Something",
                Field2 = 99,
                Field3 = DateTime.Parse("2025-02-14 15:33:16")
            };

            var expectedValue = GetMessageAsXml(message);
            var formatter = TestHelpers.MockFormatter();
            var serializer = new XmlMessageSerializer(formatter.Object);
            var actualValue = serializer.SerializeMessage(message);

            actualValue.Should().Be(expectedValue);
        }

        [Fact]
        public void SerializeMessage_FormattedValue()
        {
            var expectedMessage = new TestParentMessage()
            {
                Field1 = "Nothing",
                Field2 = 99,
                Field3 = DateTime.Parse("2025-02-14 15:33:16")
            };

            var message = new TestParentMessage()
            {
                Field1 = "Something",
                Field2 = 99,
                Field3 = DateTime.Parse("2025-02-14 15:33:16")
            };

            var expectedValue = GetMessageAsXml(expectedMessage);
            var formatter = TestHelpers.MockFormatter("Nothing");
            var serializer = new XmlMessageSerializer(formatter.Object);

            var actualValue = serializer.SerializeMessage(message);

            actualValue.Should().Be(expectedValue);
        }

        [Fact]
        public void SerializeMessage_Nested()
        {
            var message = new TestParentMessage()
            {
                Field1 = "Something",
                Field2 = 99,
                Field3 = DateTime.Parse("2025-02-14 15:33:16"),
                Field4 = new TestChildMessage()
                {
                    Field1 = 100,
                    Field2 = "Something else",
                    Field3 = "Another String"
                }
            };

            var expectedValue = GetMessageAsXml(message);
            var formatter = TestHelpers.MockFormatter();
            var serializer = new XmlMessageSerializer(formatter.Object);
            var actualValue = serializer.SerializeMessage(message);

            actualValue.Should().Be(expectedValue);
        }

        [Fact]
        public void SerializeMessage_Null()
        {
            var serializer = new XmlMessageSerializer(new Formatter());
            IAccessibleMessage? message = null;
            serializer.SerializeMessage(message).Should().Be("");
        }

        private static string GetMessageAsXml(IAccessibleMessage message)
        {
            var xmlSerializer = new XmlSerializer(message.GetType());

            using (var stringWriter = new StringWriter())
            {
                using (var xmlWriter = XmlWriter.Create(stringWriter))
                {
                    xmlSerializer.Serialize(xmlWriter, message);
                }

                return stringWriter.ToString();
            }
        }

        [Fact]
        public void SerializeMessage_WithBuilder()
        {
            var message = new TestParentMessage()
            {
                Field1 = "Something",
                Field2 = 99,
                Field3 = DateTime.Parse("2025-02-14 15:33:16")
            };

            var builder = new StringBuilder();
            var expectedValue = GetMessageAsXml(message);
            var formatter = TestHelpers.MockFormatter();
            var serializer = new XmlMessageSerializer(formatter.Object);
            serializer.SerializeMessage(message, builder);

            builder.ToString().Should().Be(expectedValue);
        }
    }
}
