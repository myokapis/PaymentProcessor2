namespace Payment.Workflow.Interfaces
{
    public interface IWorkflowContext
    {
        bool WorkflowState { get; set; }
    }

    public interface IPaymentWorkflowContext<TTransaction, TResult> : IWorkflowContext
        where TTransaction : class
        where TResult : class
    {
        TResult TransactionResult { get; set; }
        TTransaction Transaction { get; set; }
    }
}
