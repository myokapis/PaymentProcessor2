using Payment.Messages.Factories.Delegates;
using Payment.Messages.Serializers;
using System.Text;

namespace Payment.Messages.Mappers
{
    public abstract class ParentMapper<TContext, TMessage> : Mapper<TContext, TMessage>
        where TMessage : IAccessibleMessage
    {
        protected MapperFactory<TContext> mapperFactory;
        protected IMessageSerializer messageSerializer;

        public ParentMapper(MapperFactory<TContext> mapperFactory, IMessageSerializer messageSerializer) : base()
        {
            this.mapperFactory = mapperFactory;
            this.messageSerializer = messageSerializer;
        }

        protected virtual IAccessibleMessage MapGroup<TChildMapper>(TContext messageContext) where TChildMapper : IMapper<TContext>
        {
            var mapper = mapperFactory(typeof(TChildMapper));
            if (mapper == null) throw new ArgumentNullException(nameof(messageContext));

            return mapper.Map(messageContext);
        }

        protected virtual string MapValueGroup<TChildMapper>(TContext messageContext, StringBuilder builder) where TChildMapper : IMapper<TContext>
        {
            var message = MapGroup<TChildMapper>(messageContext);
            builder.Clear();
            messageSerializer.SerializeMessage(message, builder);
            return builder.ToString();
        }
    }
}
