namespace Payment.Workflow.Interfaces
{
    /// <summary>
    /// A repository for objects that need to be persisted between tasks
    /// </summary>
    public interface IWorkflowContext
    {
        /// <summary>
        /// Indicates whether the workflow is in a valid state for processing or in an errored state
        /// </summary>
        bool WorkflowState { get; set; }
    }

    /// <summary>
    /// A repository for objects that need to be persisted between tasks. This interface is
    /// specific to payment processing.
    /// </summary>
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
