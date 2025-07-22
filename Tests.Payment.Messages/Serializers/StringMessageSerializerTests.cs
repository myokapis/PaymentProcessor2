using System.Text;
using FluentAssertions;
using Payment.Messages;
using Payment.Messages.Serializers;
using Payment.Messages.Serializers.Formatters;
using Tests.Payment.Messages.Helpers;

namespace Tests.Payment.Messages.Serializers
{
    public class StringMessageSerializerTests
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

            var expectedValue = "Something992025-02-14T15:33:16";
            var formatter = TestHelpers.MockFormatter();
            var serializer = new StringMessageSerializer(formatter.Object);
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

            var expectedValue = "Something992025-02-14T15:33:16100Something elseAnother String";
            var formatter = TestHelpers.MockFormatter();
            var serializer = new StringMessageSerializer(formatter.Object);
            var actualValue = serializer.SerializeMessage(message);

            actualValue.Should().Be(expectedValue);
        }

        [Fact]
        public void SerializeMessage_Null()
        {
            var serializer = new StringMessageSerializer(new Formatter());
            IAccessibleMessage? message = null;
            serializer.SerializeMessage(message).Should().Be("");
        }

        [Fact]
        public void SerializeMessage_Terminated()
        {
            var message = new TestTerminatedMessage()
            {
                Field1 = "Something",
                Field2 = 99,
                Field3 = DateTime.Parse("2025-02-14 15:33:16"),
                Field5 = "Anything"
            };

            var expectedValue = "Something!992025-02-14T15:33:16Anything^^";
            var formatter = TestHelpers.MockFormatter();
            var serializer = new StringMessageSerializer(formatter.Object);
            var actualValue = serializer.SerializeMessage(message);

            actualValue.Should().Be(expectedValue);
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
            var expectedValue = "Something992025-02-14T15:33:16";
            var formatter = TestHelpers.MockFormatter();
            var serializer = new StringMessageSerializer(formatter.Object);
            serializer.SerializeMessage(message, builder);

            builder.ToString().Should().Be(expectedValue);
        }
    }
}
