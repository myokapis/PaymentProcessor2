using Payment.Workflow;
using Payment.Workflow.Factories.Delegates;
using Payment.Workflow.Interfaces;

namespace Tests.Payment.Workflow.Helpers
{
    public class TestWorkflowRunner : WorkflowRunner<TestWorkflowContext>
    {
        public TestWorkflowRunner(WorkflowTaskFactory workflowTaskFactory,
            IWorkflowContext workflowContext) : base(workflowTaskFactory, workflowContext)
        {
        }

        public int ExceptionCount { get; set; }

        protected override void HandleException(Exception exception)
        {
            ExceptionCount++;
        }

        protected override async Task RunWorkflowTasks()
        {
            RunWorkflowTask<TestWorkflowTask>();
            await RunWorkflowTaskAsync<TestWorkflowTaskAsync>();
            await Task.CompletedTask;
        }
    }
}
