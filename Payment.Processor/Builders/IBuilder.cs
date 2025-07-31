using Payment.Processor.Transaction.Context;
using Payment.Processor.Transaction.Model;

namespace Payment.Processor.Builders
{
    public interface IBuilder<T>
    {
        T Build(ITransactionModel transaction) => throw new NotImplementedException();
        T Build(ITransactionModel transaction, IActionContext context)
            => throw new NotImplementedException();
    }
}
