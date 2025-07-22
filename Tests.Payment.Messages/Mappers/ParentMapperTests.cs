using FluentAssertions;
using Moq;
using Payment.Messages.Factories.Delegates;
using Payment.Messages.Mappers;
using Payment.Messages.Serializers;
using Tests.Payment.Messages.Helpers;

namespace Tests.Payment.Messages.Mappers
{
    // TODO: mock child mapper
    public class ParentMapperTests
    {
        [Fact]
        public void MapGroupAndValueGroup()
        {
            var childMapper = new TestChildMapper();
            var mockMapperFactory = new Mock<MapperFactory<TestMessageContext>>();
            mockMapperFactory.Setup(m => m(It.IsAny<Type>())).Returns(childMapper);

            var mockSerializer = new Mock<IMessageSerializer>();

            var parentMapper = new TestParentMapper(mockMapperFactory.Object, mockSerializer.Object);
            parentMapper.Map(new TestMessageContext());
        }

        [Fact]
        public void MapGroup_InvalidMapper()
        {
            var childMapper = new TestChildMapper();
            var mockMapperFactory = new Mock<MapperFactory<TestMessageContext>>();
            mockMapperFactory.Setup(m => m(It.IsAny<Type>())).Returns((IMapper<TestMessageContext>?)null);

            var mockSerializer = new Mock<IMessageSerializer>();

            var parentMapper = new TestParentMapper(mockMapperFactory.Object, mockSerializer.Object);
            var exception = Assert.Throws<ArgumentNullException>(() => parentMapper.Map(new TestMessageContext()));
            exception.Message.Should().Be("Value cannot be null. (Parameter 'messageContext')");
        }
    }
}
