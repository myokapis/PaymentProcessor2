using Payment.Processor.Transaction.Context;
using Payment.Processor.Transaction.Model;

namespace Payment.Processor.Builders
{
    public interface IBuilder<T>
    {
        // TODO: should T be nullable?
        T Build(ITransactionModel transaction) => throw new NotImplementedException();
        T Build<TContext>(ITransactionModel transaction, IContext context) where TContext : class
            => throw new NotImplementedException();
    }
}
