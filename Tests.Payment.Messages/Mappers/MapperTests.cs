using FluentAssertions;
using Payment.Messages;
using Payment.Messages.Mappers;
using Tests.Payment.Messages.Helpers;

namespace Tests.Payment.Messages.Mappers
{
    public class MapperTests
    {
        [Fact]
        public void Map()
        {
            var mapper = new TestMapper();
            var messageContext = new TestMessageContext();

            Assert.Throws<NotImplementedException>(() => mapper.Map(messageContext));
        }

        [Fact]
        public void SetFields()
        {
            var message = new TestParentMessage();
            var nestedMessage = new TestChildMessage();

            var data = new Dictionary<string, object?>()
            {
                { "Field1", "Some Value" },
                { "Field2", 99 },
                { "Field3", DateTime.Parse("2025-02-14 13:55:33") },
                { "Field4", nestedMessage }
            };

            var mapper = new TestMapper();
            mapper.SetFields(message, data);

            var messageValues = new Dictionary<string, object?>()
            {
                { "Field1", message.Field1 },
                { "Field2", message.Field2 },
                { "Field3", message.Field3 },
                { "Field4", message.Field4 }
            };

            messageValues.Should().Equal(data);
        }

        private class TestMapper : Mapper<TestMessageContext, TestParentMessage>
        {
            public override IAccessibleMessage Map(TestMessageContext messageContext)
            {
                throw new NotImplementedException();
            }
        }
    }
}
