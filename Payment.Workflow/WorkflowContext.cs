using Payment.Workflow.Interfaces;

namespace Payment.Workflow
{
    public abstract class WorkflowContext : IWorkflowContext

    {
        public WorkflowContext()
        { }

        public bool WorkflowState { get; set; } = true;
    }
}
