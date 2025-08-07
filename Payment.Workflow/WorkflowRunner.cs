using Payment.Workflow.Factories.Delegates;
using Payment.Workflow.Interfaces;

namespace Payment.Workflow
{
    /// <summary>
    /// A base class for defining a workflow runner to manage a set of tasks.
    /// </summary>
    public abstract class WorkflowRunner : IWorkflowRunner
    {
        protected readonly IWorkflowContext workflowContext;
        protected readonly WorkflowTaskFactory workflowTaskFactory;

        /// <summary>
        /// Constructs a new workflow runner instance.
        /// </summary>
        /// <param name="workflowTaskFactory">A delegate that provides workflow tasks.</param>
        /// <param name="workflowContext">A repository for sharing data between tasks.</param>
        public WorkflowRunner(WorkflowTaskFactory workflowTaskFactory, IWorkflowContext workflowContext)
        {
            
            this.workflowTaskFactory = workflowTaskFactory;
            this.workflowContext = workflowContext;
            workflowContext.WorkflowState = true;
        }

        /// <summary>
        /// Entry point for starting execution of a workflow.
        /// </summary>
        /// <returns>Whether the workflow completed successfully (true) or with errors (false)</returns>
        public async virtual Task<bool> RunAsync()
        {
            await RunWorkflowTasks();
            return workflowContext.WorkflowState;
        }

        /// <summary>
        /// An abstract method in which inheriting classes can add the tasks to be run in the workflow.
        /// </summary>
        /// <returns>An awaitable task</returns>
        protected abstract Task RunWorkflowTasks();

        /// <summary>
        /// An abstract method in which inheriting classes can implement code to be run when an error occurs.
        /// </summary>
        /// <param name="exception"></param>
        protected abstract void HandleException(Exception exception);
 
        protected void RunWorkflowTask<T>() where T : IWorkflowTask
        {
            try
            {
                var workflowTask = workflowTaskFactory(typeof(T));
                workflowContext.WorkflowState = workflowTask.Run();
            }
            catch(Exception e)
            {
                workflowContext.WorkflowState = false;
                HandleException(e);
            }
        }

        protected async Task RunWorkflowTaskAsync<T>() where T : IWorkflowTask
        {
            try
            {
                var workflowTask = workflowTaskFactory(typeof(T));
                var result = await workflowTask.RunAsync();
                workflowContext.WorkflowState = result;
            }
            catch (Exception e)
            {
                workflowContext.WorkflowState = false;
                HandleException(e);
            }
        }
    }



    /// <summary>
    /// A base class for defining a workflow runner to manage a set of tasks using a specific context.
    /// </summary>
    /// <typeparam name="TContext">The type of the context that will be shared by the tasks.</typeparam>
    public abstract class WorkflowRunner<TContext> : WorkflowRunner, IWorkflowRunner<TContext> where TContext : IWorkflowContext
    {
        /// <summary>
        /// Constructs a new workflow runner instance.
        /// </summary>
        /// <param name="workflowTaskFactory">A delegate that provides workflow tasks.</param>
        /// <param name="workflowContext">A repository for sharing data between tasks.</param>
        protected WorkflowRunner(WorkflowTaskFactory workflowTaskFactory, IWorkflowContext workflowContext) : base(workflowTaskFactory, workflowContext)
        {
        }

        /// <summary>
        /// The workflow context that is shared by tasks.
        /// </summary>
        public TContext WorkflowContext => (TContext)workflowContext;
    }
}
