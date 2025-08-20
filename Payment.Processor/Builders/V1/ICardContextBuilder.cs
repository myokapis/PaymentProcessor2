using Payment.Processor.Transaction.Context.V1;
using Payment.Processor.Transaction.Model.V1;

namespace Payment.Processor.Builders.V1
{
    /// <summary>
    /// Describes the basic functionality of a card context builder.
    /// </summary>
    public interface ICardContextBuilder
    {
        /// <summary>
        /// Builds a card context class asynchronously using a transaction model as a data source.
        /// </summary>
        /// <param name="transaction">A credit card payment transaction model.</param>
        /// <returns>An instance of the card context class.</returns>
        Task<CardContext> BuildAsync(ITransactionModel transaction);
    }
}
