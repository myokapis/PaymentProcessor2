using Payment.Workflow;

namespace Tests.Payment.Workflow.Helpers
{
    internal class TestWorkflowTaskAsync : WorkflowTaskAsync<TestWorkflowContext>
    {
        private readonly bool throwException;

        public TestWorkflowTaskAsync(TestWorkflowContext workflowContext, bool throwException) : base(workflowContext)
        {
            this.throwException = throwException;
        }

        protected override async Task<bool> RunActiveAsync()
        {
            if (throwException) throw new InvalidOperationException();
            return await Task.FromResult(true);
        }

        //protected override async Task<bool> RunErroredAsync()
        //{
        //    if (throwException) throw new InvalidOperationException();
        //    return await Task.FromResult(false);
        //}
    }
}
