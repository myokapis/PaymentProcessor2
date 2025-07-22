namespace Payment.Workflow.Interfaces
{
    public interface IWorkflowTask
    {
        bool Run() => throw new NotImplementedException();
        Task<bool> RunAsync() => throw new NotImplementedException();
    }
}
