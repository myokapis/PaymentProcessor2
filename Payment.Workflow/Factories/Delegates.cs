using Payment.Workflow.Interfaces;

namespace Payment.Workflow.Factories.Delegates
{
    /// <summary>
    /// A delegate for constructing a task.
    /// </summary>
    /// <param name="type">The type of the delegate to be constructed.</param>
    /// <returns>The constructed delegate.</returns>
    public delegate IWorkflowTask WorkflowTaskFactory(Type type);
}

