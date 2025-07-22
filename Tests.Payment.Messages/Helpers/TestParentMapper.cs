using System.Text;
using Payment.Messages;
using Payment.Messages.Attributes.Serialization;
using Payment.Messages.Factories.Delegates;
using Payment.Messages.Mappers;
using Payment.Messages.Serializers;

namespace Tests.Payment.Messages.Helpers
{
    public class TestParentMapper : ParentMapper<TestMessageContext, TestParentMessage>
    {
        public TestParentMapper(MapperFactory<TestMessageContext> mapperFactory, IMessageSerializer messageSerializer) : base(mapperFactory, messageSerializer)
        {
        }

        public override IAccessibleMessage Map(TestMessageContext messageContext)
        {
            var builder = new StringBuilder();

            return new TestParentMessage()
            {
                 Field1 = "Field1",
                 Field2 = 99,
                 Field3 = DateTime.Parse("2025-02-13 14:33:55"),
                 Field4 = (TestChildMessage)MapGroup<TestChildMapper>(messageContext),
                 Field5 = MapValueGroup<TestChildMapper>(messageContext, builder)
            };
        }
    }
}
