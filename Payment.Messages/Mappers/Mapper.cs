namespace Payment.Messages.Mappers
{
    /// <summary>
    /// An abstract class expressing base mapper behavior.
    /// </summary>
    /// <typeparam name="TContext">The type of the message context that will
    /// provide data for the message.</typeparam>
    /// <typeparam name="TMessage">The type of the message to be constructed.</typeparam>
    public abstract class Mapper<TContext, TMessage> : IMapper<TContext>
        where TMessage : IAccessibleMessage
    {
        /// <summary>
        /// Constructs an instance of the mapper.
        /// </summary>
        public Mapper()
        { }

        /// <summary>
        /// An abstract method in which inheriting classes define how data is to be mapped from
        /// the message context to the message.
        /// </summary>
        /// <param name="messageContext">A context providing data for the message.</param>
        /// <returns>An instance of the message with field values set.</returns>
        public abstract IAccessibleMessage Map(TContext messageContext);

        /// <summary>
        /// Sets the field values on a message using the data from the field values collection.
        /// </summary>
        /// <param name="message">The message on which data is to be set.</param>
        /// <param name="fieldValues">The collection of values to be used when setting message field values.</param>
        /// <returns>An instance of the message with field values set.</returns>
        public virtual IAccessibleMessage SetFields(IAccessibleMessage message, Dictionary<string, object?> fieldValues)
        {
            foreach (var fieldDefinition in message.FieldDefinitions)
            {
                var property = fieldDefinition.PropertyInfo;
                if (!fieldValues.ContainsKey(property.Name)) continue;

                var value = fieldValues[property.Name];
                property.SetValue(message, value);
            }

            return message;
        }
    }
}
