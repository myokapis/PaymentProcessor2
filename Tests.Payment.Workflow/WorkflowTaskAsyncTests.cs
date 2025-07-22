using FluentAssertions;
using Tests.Payment.Workflow.Helpers;

namespace Tests.Payment.Workflow
{
    public class WorkflowTaskAsyncTests
    {
        [Fact]
        public async Task Run_Active()
        {
            var workflowContext = new TestWorkflowContext() { WorkflowState = true };
            var testTask = new TestWorkflowTaskAsync(workflowContext, false);
            var result = await testTask.RunAsync();
            result.Should().BeTrue();
        }

        [Fact]
        public async Task Run_Errored()
        {
            var workflowContext = new TestWorkflowContext() { WorkflowState = false };
            var testTask = new TestWorkflowTaskAsync(workflowContext, false);
            var result = await testTask.RunAsync();
            result.Should().BeFalse();
        }

        [Fact]
        public void WorkflowContext()
        {
            var workflowContext = new TestWorkflowContext() { WorkflowState = false };
            var testTask = new TestWorkflowTaskAsync(workflowContext, false);
            testTask.WorkflowContext.Should().Be(workflowContext);
        }
    }
}
