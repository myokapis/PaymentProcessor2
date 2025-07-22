namespace Payment.Messages.Mappers
{
    public interface IMapper
    {
        IAccessibleMessage SetFields(IAccessibleMessage message, Dictionary<string, object?> fieldValues);
    }

    public interface IMapper<TContext> : IMapper
    {
        IAccessibleMessage Map(TContext messageContext);
    }
}
