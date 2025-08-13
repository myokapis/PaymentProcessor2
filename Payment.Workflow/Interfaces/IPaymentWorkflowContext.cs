namespace Payment.Workflow.Interfaces
{
    /// <summary>
    /// A repository for objects that need to be persisted between tasks
    /// </summary>
    /// <typeparam name="TTransaction">The type of the transaction to be processed.</typeparam>
    /// <typeparam name="TResult">The type of the context that describes the result.</typeparam>
    public interface IPaymentWorkflowContext<TTransaction, TResult> : IWorkflowContext
        where TTransaction : class
        where TResult : class
    {
        /// <summary>
        /// The object representing the result of payment processing
        /// </summary>
        TResult? TransactionResult { get; set; }

        /// <summary>
        /// The transaction object for the transaction being processed
        /// </summary>
        TTransaction? Transaction { get; set; }
    }
}
