using FluentAssertions;
using Tests.Payment.Workflow.Helpers;

namespace Tests.Payment.Workflow
{
    public class WorkflowTaskTests
    {
        [Fact]
        public void Run_Active()
        {
            var workflowContext = new TestWorkflowContext() { WorkflowState = true };
            var testTask = new TestWorkflowTask(workflowContext, false);
            var result = testTask.Run();
            result.Should().BeTrue();
        }

        [Fact]
        public void Run_Errored()
        {
            var workflowContext = new TestWorkflowContext() { WorkflowState = false };
            var testTask = new TestWorkflowTask(workflowContext, false);
            var result = testTask.Run();
            result.Should().BeFalse();
        }

        [Fact]
        public void WorkflowContext()
        {
            var workflowContext = new TestWorkflowContext() { WorkflowState = false };
            var testTask = new TestWorkflowTask(workflowContext, false);
            testTask.WorkflowContext.Should().Be(workflowContext);
        }
    }
}
