using Payment.Processor.Transaction.Model;

namespace Payment.Processor.Builders
{
    public interface IBuilderAsync<T>
    {
        Task<T> BuildAsync(ITransactionModel transaction);
    }
}
