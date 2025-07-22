namespace Payment.Workflow.Interfaces
{
    public interface IWorkflowRunner
    {
        Task<bool> RunAsync();
    }
}
