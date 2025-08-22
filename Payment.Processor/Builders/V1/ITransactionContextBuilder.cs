using Payment.Processor.Transaction.Context.V1;
using Payment.Processor.Transaction.Model.V1;

namespace Payment.Processor.Builders.V1
{
    /// <summary>
    /// Describes the basic functionality of a transaction context builder.
    /// </summary>
    /// <typeparam name="TEnvelope">The type of the envelope contained in the transaction context.</typeparam>
    /// <typeparam name="TAttributes">The type of the processor attributes contained in the transaction context.</typeparam>
    public interface ITransactionContextBuilder<TEnvelope, TAttributes>
        where TEnvelope : IEnvelope
        where TAttributes : IProcessorAttributes
    {
        /// <summary>
        /// Builds a card on file context from a transaction and other associated contexts.
        /// </summary>
        /// <typeparam name="TTransactionContext">The type of the transaction context to build.</typeparam>
        /// <param name="transaction">A credit card payment transaction model.</param>
        /// <returns>An instance of the transaction context class.</returns>
        Task<TTransactionContext> BuildAsync<TTransactionContext>(ITransactionModel transaction)
            where TTransactionContext : ITransactionContext<TEnvelope, TAttributes>, new();
    }
}
