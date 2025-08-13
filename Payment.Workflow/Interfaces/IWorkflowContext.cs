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
}
