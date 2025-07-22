using Payment.Workflow.Interfaces;

namespace Payment.Workflow
{
    public abstract class WorkflowTask : IWorkflowTask
    {
        protected readonly IWorkflowContext workflowContext;

        public WorkflowTask(IWorkflowContext workflowContext)
        {
            this.workflowContext = workflowContext;
        }

        public bool Run()
        {
            if (workflowContext.WorkflowState)
            {
                return RunActive();
            }
            else return RunErrored();
        }

        protected abstract bool RunActive();

        protected virtual bool RunErrored()
        {
            return false;
        }
    }

    public abstract class WorkflowTask<T> : WorkflowTask where T : IWorkflowContext
    {
        protected WorkflowTask(T workflowContext) : base(workflowContext)
        {
        }

        public T WorkflowContext => (T)workflowContext;
    }
}
