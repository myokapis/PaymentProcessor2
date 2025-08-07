using Payment.Workflow.Interfaces;

namespace Payment.Workflow
{
    /// <summary>
    /// An abstract class for defining a unit of work.
    /// </summary>
    public abstract class WorkflowTask : IWorkflowTask
    {
        protected readonly IWorkflowContext workflowContext;

        /// <summary>
        /// Constructs a new task instance.
        /// </summary>
        /// <param name="workflowContext">The repository that is shared between tasks.</param>
        public WorkflowTask(IWorkflowContext workflowContext)
        {
            this.workflowContext = workflowContext;
        }

        /// <summary>
        /// Initiates execution of the task.
        /// </summary>
        /// <returns>Indicates if the context is in a valid state after execution (true)
        /// or in an errored state (false).</returns>
        public bool Run()
        {
            if (workflowContext.WorkflowState)
            {
                return RunActive();
            }
            else return RunErrored();
        }

        /// <summary>
        /// An abstract method in which inheriting classes can implement a unit of work.
        /// This method runs only when the context is in a valid state.
        /// </summary>
        /// <returns>Indicates if the context is in a valid state after execution (true)
        /// or in an errored state (false).</returns>
        protected abstract bool RunActive();

        /// <summary>
        /// A default implementation of the unit of work to be run when the context is in
        /// an errored state.
        /// </summary>
        /// <returns>Indicates if the context is in a valid state after execution (true)
        /// or in an errored state (false).</returns>
        protected virtual bool RunErrored()
        {
            return false;
        }
    }

    /// <summary>
    /// An abstract class for defining a unit of work using a specific context.
    /// </summary>
    /// <typeparam name="T">The type of the context that is shared between tasks.</typeparam>
    public abstract class WorkflowTask<T> : WorkflowTask where T : IWorkflowContext
    {
        /// <summary>
        /// Constructs an instance of a task.
        /// </summary>
        /// <param name="workflowContext">The context that is shared between tasks.</param>
        protected WorkflowTask(T workflowContext) : base(workflowContext)
        {
        }

        /// <summary>
        /// The context that is shared between tasks.
        /// </summary>
        public T WorkflowContext => (T)workflowContext;
    }
}
