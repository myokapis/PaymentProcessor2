using Payment.Messages.Mappers;

namespace Payment.Messages.Factories.Delegates
{
    /// <summary>
    /// A delegate for creating mapper classes.
    /// </summary>
    /// <typeparam name="TContext">The type of the context to be included in the mapper.</typeparam>
    /// <param name="type">The type of the mapper to be constructed.</param>
    /// <returns>An instance of the mapper type.</returns>
    public delegate IMapper<TContext>? MapperFactory<TContext>(Type type);
}

