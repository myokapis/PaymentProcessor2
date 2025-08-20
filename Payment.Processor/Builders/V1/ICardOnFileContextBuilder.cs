using Payment.Processor.Transaction.Context.V1;
using Payment.Processor.Transaction.Model.V1;

namespace Payment.Processor.Builders.V1
{
    /// <summary>
    /// Describes the basic functionality of a card on file context builder.
    /// </summary>
    public interface ICardOnFileContextBuilder
    {
        /// <summary>
        /// Builds a card on file context from a transaction and its associated action context.
        /// </summary>
        /// <param name="transaction">A credit card payment transaction model.</param>
        /// <param name="actionContext">The action context associated with the transaction.</param>
        /// <returns>An instance of the card on file context class.</returns>
        CardOnFileContext Build(ITransactionModel transaction, IActionContext actionContext);
    }
}
