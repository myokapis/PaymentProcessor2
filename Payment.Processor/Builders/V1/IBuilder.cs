using Payment.Processor.Transaction.Context;
using Payment.Processor.Transaction.Model;

namespace Payment.Processor.Builders
{
    /// <summary>
    /// Describes the basic functionality of a generic class builder.
    /// </summary>
    /// <typeparam name="T">The type of the class to be built.</typeparam>
    public interface IBuilder<T>
    {
        /// <summary>
        /// Builds a class using a transaction model as a data source.
        /// </summary>
        /// <param name="transaction">A credit card payment transaction model.</param>
        /// <returns>An instance of the class being built.</returns>
        /// <exception cref="NotImplementedException">Raises when the method is not present on the implementing class.
        /// Implementing classes can choose the appropriate method signature to implement.</exception>
        T Build(ITransactionModel transaction) => throw new NotImplementedException();

        /// <summary>
        /// Builds a class using a transaction model and an action context as a data source.
        /// </summary>
        /// <param name="transaction">A credit card payment transaction model.</param>
        /// <param name="context">An action context instance.</param>
        /// <returns>An instance of the class being built.</returns>
        /// <exception cref="NotImplementedException">Raises when the method is not present on the implementing class.
        /// Implementing classes can choose the appropriate method signature to implement.</exception>
        T Build(ITransactionModel transaction, IActionContext context)
            => throw new NotImplementedException();
    }
}
