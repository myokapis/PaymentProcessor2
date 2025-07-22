using Payment.Workflow.Interfaces;

namespace Payment.Workflow
{
    public abstract class WorkflowTaskAsync : IWorkflowTask
    {
        protected readonly IWorkflowContext workflowContext;

        public WorkflowTaskAsync(IWorkflowContext workflowContext)
        {
            this.workflowContext = workflowContext;
        }

        //public IWorkflowContext WorkflowContext { get; init; }

        public async Task<bool> RunAsync()
        {
            if (workflowContext.WorkflowState)
            {
                return await RunActiveAsync();
            }
            else return await RunErroredAsync();
        }

        protected abstract Task<bool> RunActiveAsync();

        protected virtual async Task<bool> RunErroredAsync()
        {
            return await Task.FromResult(false);
        }
    }

    public abstract class WorkflowTaskAsync<T> : WorkflowTaskAsync where T : IWorkflowContext
    {
        protected WorkflowTaskAsync(T workflowContext) : base(workflowContext)
        {
        }

        public T WorkflowContext => (T)workflowContext;
    }
}
