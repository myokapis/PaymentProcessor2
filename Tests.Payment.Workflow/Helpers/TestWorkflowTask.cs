using Payment.Workflow;

namespace Tests.Payment.Workflow.Helpers
{
    internal class TestWorkflowTask : WorkflowTask<TestWorkflowContext>
    {
        private readonly bool throwException;

        public TestWorkflowTask(TestWorkflowContext workflowContext, bool throwException) : base(workflowContext)
        {
            this.throwException = throwException;
        }

        protected override bool RunActive()
        {
            if (throwException) throw new InvalidOperationException();
            return true;
        }

        //protected override bool RunErrored()
        //{
        //    if (throwException) throw new InvalidOperationException();
        //    return false;
        //}
    }
}
