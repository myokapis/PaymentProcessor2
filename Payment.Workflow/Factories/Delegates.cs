using Payment.Workflow.Interfaces;

namespace Payment.Workflow.Factories.Delegates
{
    public delegate IWorkflowTask WorkflowTaskFactory(Type type);
}

