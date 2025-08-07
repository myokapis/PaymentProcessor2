using Payment.Messages.Factories.Delegates;
using Payment.Messages.Serializers;
using System.Text;

namespace Payment.Messages.Mappers
{
    /// <summary>
    /// An abstract class expressing base mapper behavior for message classes that contain nested groups.
    /// </summary>
    /// <typeparam name="TContext">The type of the message context that will
    /// provide data for the message.</typeparam>
    /// <typeparam name="TMessage">The type of the message to be constructed.</typeparam>
    public abstract class ParentMapper<TContext, TMessage> : Mapper<TContext, TMessage>
        where TMessage : IAccessibleMessage
    {
        protected MapperFactory<TContext> mapperFactory;
        protected IMessageSerializer messageSerializer;

        /// <summary>
        /// Constructs an instance of the parent mapper class.
        /// </summary>
        /// <param name="mapperFactory">A delegate to construct a nested mapper class.</param>
        /// <param name="messageSerializer">A serializer for transforming value groups into a string.</param>
        public ParentMapper(MapperFactory<TContext> mapperFactory, IMessageSerializer messageSerializer) : base()
        {
            this.mapperFactory = mapperFactory;
            this.messageSerializer = messageSerializer;
        }

        /// <summary>
        /// A convenience method that delegates mapping of a nested group to another mapper.
        /// </summary>
        /// <typeparam name="TChildMapper">The class of the child mapper to which nested group mapping will be delegated.</typeparam>
        /// <param name="messageContext">A context providing data for the nested group.</param>
        /// <returns>An instance of the nested group with field values set.</returns>
        /// <exception cref="ArgumentNullException">Throws if the child mapper cannot be constructed.</exception>
        protected virtual IAccessibleMessage MapGroup<TChildMapper>(TContext messageContext) where TChildMapper : IMapper<TContext>
        {
            var mapper = mapperFactory(typeof(TChildMapper));
            if (mapper == null) throw new ArgumentNullException(nameof(messageContext));

            return mapper.Map(messageContext);
        }

        /// <summary>
        /// A convenience method that delegates mapping of a nested group to another mapper.
        /// The nested group is serialized and returned as a string.
        /// </summary>
        /// <typeparam name="TChildMapper">The class of the child mapper to which nested group mapping will be delegated.</typeparam>
        /// <param name="messageContext">A context providing data for the nested group.</param>
        /// <param name="builder">A string builder instance to be used in serialization.</param>
        /// <returns>A string representing the serialized nested group.</returns>
        protected virtual string MapValueGroup<TChildMapper>(TContext messageContext, StringBuilder builder) where TChildMapper : IMapper<TContext>
        {
            var message = MapGroup<TChildMapper>(messageContext);
            builder.Clear();
            messageSerializer.SerializeMessage(message, builder);
            return builder.ToString();
        }
    }
}
