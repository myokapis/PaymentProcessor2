using Payment.Workflow.Interfaces;

namespace Payment.Workflow
{
    /// <summary>
    /// A repository for objects that need to be persisted between tasks. Inheriting classes
    /// are expected to add properties for their specific workflow.
    /// </summary>
    public abstract class WorkflowContext : IWorkflowContext

    {
        public WorkflowContext()
        { }

        /// <summary>
        /// Indicates whether the workflow is in a valid state for processing or in an errored state
        /// </summary>
        public bool WorkflowState { get; set; } = true;
    }
}
