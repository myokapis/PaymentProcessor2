using Payment.Workflow.Interfaces;

namespace Payment.Workflow
{
    /// <summary>
    /// An abstract class for defining a unit of work to be run asynchronously.
    /// </summary>
    public abstract class WorkflowTaskAsync : IWorkflowTask
    {
        protected readonly IWorkflowContext workflowContext;

        /// <summary>
        /// Constructs a new task instance.
        /// </summary>
        /// <param name="workflowContext">The repository that is shared between tasks.</param>
        public WorkflowTaskAsync(IWorkflowContext workflowContext)
        {
            this.workflowContext = workflowContext;
        }

        /// <summary>
        /// Initiates execution of the task asynchronously.
        /// </summary>
        /// <returns>Indicates if the context is in a valid state after execution (true)
        /// or in an errored state (false).</returns>
        public async Task<bool> RunAsync()
        {
            if (workflowContext.WorkflowState)
            {
                return await RunActiveAsync();
            }
            else return await RunErroredAsync();
        }

        /// <summary>
        /// An abstract method in which inheriting classes can implement a unit of work
        /// to be run asynchronously.
        /// This method runs only when the context is in a valid state.
        /// </summary>
        /// <returns>Indicates if the context is in a valid state after execution (true)
        /// or in an errored state (false).</returns>
        protected abstract Task<bool> RunActiveAsync();

        /// <summary>
        /// A default implementation of the unit of work to be run when the context is in
        /// an errored state.
        /// </summary>
        /// <returns>Indicates if the context is in a valid state after execution (true)
        /// or in an errored state (false).</returns>
        protected virtual async Task<bool> RunErroredAsync()
        {
            return await Task.FromResult(false);
        }
    }

    /// <summary>
    /// An abstract class for defining a unit of work to be run asynchronously using a specific context.
    /// </summary>
    /// <typeparam name="T">The type of the context that is shared between tasks.</typeparam>
    public abstract class WorkflowTaskAsync<T> : WorkflowTaskAsync where T : IWorkflowContext
    {

        /// <summary>
        /// Constructs an instance of a task.
        /// </summary>
        /// <param name="workflowContext">The context that is shared between tasks.</param>
        protected WorkflowTaskAsync(T workflowContext) : base(workflowContext)
        {
        }

        /// <summary>
        /// The context that is shared between tasks.
        /// </summary>
        public T WorkflowContext => (T)workflowContext;
    }
}
