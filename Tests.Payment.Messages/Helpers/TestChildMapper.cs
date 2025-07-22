using Payment.Messages;
using Payment.Messages.Factories.Delegates;
using Payment.Messages.Mappers;
using Payment.Messages.Serializers;

namespace Tests.Payment.Messages.Helpers
{
    public class TestChildMapper : Mapper<TestMessageContext, TestChildMessage>
    {
        public TestChildMapper() : base()
        {
        }

        public override IAccessibleMessage Map(TestMessageContext messageContext)
        {
            return new TestChildMessage()
            {
                 Field1 = 1,
                 Field2 = "String 2",
                 Field3 = "String 3"
            };
        }
    }
}
