namespace Payment.Messages.Mappers
{
    /// <summary>
    /// Describes base mapper behavior.
    /// </summary>
    public interface IMapper
    {
        /// <summary>
        /// Sets the field values on a message using the data from the field values collection.
        /// </summary>
        /// <param name="message">The message on which data is to be set.</param>
        /// <param name="fieldValues">The collection of values to be used when setting message field values.</param>
        /// <returns>An instance of the message with field values set.</returns>
        IAccessibleMessage SetFields(IAccessibleMessage message, Dictionary<string, object?> fieldValues);
    }

    /// <summary>
    /// Describes base mapper behavior using a specific context.
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public interface IMapper<TContext> : IMapper
    {
        /// <summary>
        /// Maps data from the message context to a message.
        /// </summary>
        /// <param name="messageContext">A context providing data for the message.</param>
        /// <returns>An instance of the message with field values set.</returns>
        IAccessibleMessage Map(TContext messageContext);
    }
}
