namespace Payment.Workflow.Interfaces
{
    public interface IWorkflowContext
    {
        bool WorkflowState { get; set; }
    }
}
