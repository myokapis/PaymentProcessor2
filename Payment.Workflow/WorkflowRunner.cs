using Payment.Workflow.Factories.Delegates;
using Payment.Workflow.Interfaces;

namespace Payment.Workflow
{
    public abstract class WorkflowRunner : IWorkflowRunner
    {
        protected readonly IWorkflowContext workflowContext;
        protected readonly WorkflowTaskFactory workflowTaskFactory;

        public WorkflowRunner(WorkflowTaskFactory workflowTaskFactory, IWorkflowContext workflowContext)
        {
            
            this.workflowTaskFactory = workflowTaskFactory;
            this.workflowContext = workflowContext;
            workflowContext.WorkflowState = true;
        }

        public async virtual Task<bool> RunAsync()
        {
            await RunWorkflowTasks();
            return workflowContext.WorkflowState;
        }

        protected abstract Task RunWorkflowTasks();

        protected abstract void HandleException(Exception exception);
 
        // TODO: implement some kind of logging and tracing
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

        // TODO: implement some kind of logging and tracing
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

    public abstract class WorkflowRunner<TContext> : WorkflowRunner, IWorkflowRunner<TContext> where TContext : IWorkflowContext
    {
        protected WorkflowRunner(WorkflowTaskFactory workflowTaskFactory, IWorkflowContext workflowContext) : base(workflowTaskFactory, workflowContext)
        {
        }

        public TContext WorkflowContext => (TContext)workflowContext;
    }
}
