using Payment.Messages.Mappers;

namespace Payment.Messages.Factories.Delegates
{
    public delegate IMapper<TContext>? MapperFactory<TContext>(Type type);
}

