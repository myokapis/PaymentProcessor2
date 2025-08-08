using Payment.Processor.Transaction.Model;

namespace Payment.Processor.Builders
{
    /// <summary>
    /// Describes the basic functionality of a generic asynchronous class builder.
    /// </summary>
    /// <typeparam name="T">The type of the class to be built.</typeparam>
    public interface IBuilderAsync<T>
    {
        /// <summary>
        /// Builds a class asynchronously using a transaction model as a data source.
        /// </summary>
        /// <param name="transaction">A credit card payment transaction model.</param>
        /// <returns>An instance of the class being built.</returns>
        Task<T> BuildAsync(ITransactionModel transaction);
    }
}
