namespace Payment.Workflow.Interfaces
{
    public interface IWorkflowRunner
    {
        Task<bool> RunAsync();
    }

    public interface IWorkflowRunner<TContext> : IWorkflowRunner where TContext : IWorkflowContext
    {
        TContext WorkflowContext { get; }
    }
}
