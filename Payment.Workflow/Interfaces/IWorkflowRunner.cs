namespace Payment.Workflow.Interfaces
{
    /// <summary>
    /// Defines a workflow runner to manage a set of tasks.
    /// </summary>
    public interface IWorkflowRunner
    {
        /// <summary>
        /// Entry point for starting execution of a workflow.
        /// </summary>
        Task<bool> RunAsync();
    }

    /// <summary>
    /// Defines a workflow runner to manage a set of tasks using a specific context.
    /// </summary>
    /// <typeparam name="TContext">The type of the context that will be shared by the tasks.</typeparam>
    public interface IWorkflowRunner<TContext> : IWorkflowRunner where TContext : IWorkflowContext
    {
        /// <summary>
        /// The workflow context that is shared by tasks.
        /// </summary>
        TContext WorkflowContext { get; }
    }
}
