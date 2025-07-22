using FluentAssertions;
using Moq;
using Payment.Workflow.Factories.Delegates;
using Payment.Workflow.Interfaces;
using Tests.Payment.Workflow.Helpers;

namespace Tests.Payment.Workflow
{
    public class WorkflowRunnerTests
    {
        [Fact]
        public async Task Run()
        {
            var workflowContext = new TestWorkflowContext();
            var mockTaskFactory = MockTaskFactory(workflowContext, false, false);
            var workflowRunner = new TestWorkflowRunner(mockTaskFactory.Object, workflowContext);
            var result = await workflowRunner.RunAsync();

            workflowRunner.WorkflowContext.WorkflowState.Should().BeTrue();
            workflowRunner.ExceptionCount.Should().Be(0);
            result.Should().BeTrue();
        }

        [Fact]
        public async Task Run_Exception()
        {
            var workflowContext = new TestWorkflowContext();
            var mockTaskFactory = MockTaskFactory(workflowContext, true, false);
            var workflowRunner = new TestWorkflowRunner(mockTaskFactory.Object, workflowContext);
            var result = await workflowRunner.RunAsync();

            workflowContext.WorkflowState.Should().BeFalse();
            workflowRunner.ExceptionCount.Should().Be(1);
            result.Should().BeFalse();
        }

        [Fact]
        public async Task Run_ExceptionAsync()
        {
            var workflowContext = new TestWorkflowContext();
            var mockTaskFactory = MockTaskFactory(workflowContext, false, true);
            var workflowRunner = new TestWorkflowRunner(mockTaskFactory.Object, workflowContext);
            var result = await workflowRunner.RunAsync();

            workflowContext.WorkflowState.Should().BeFalse();
            workflowRunner.ExceptionCount.Should().Be(1);
            result.Should().BeFalse();
        }

        private Mock<WorkflowTaskFactory> MockTaskFactory(TestWorkflowContext workflowContext, bool throwsException, bool throwsExceptionAsync)
        {
            var task = new TestWorkflowTask(workflowContext, throwsException);
            var taskAsync = new TestWorkflowTaskAsync(workflowContext, throwsExceptionAsync);

            var mock = new Mock<WorkflowTaskFactory>();
            mock.Setup(m => m(It.Is<Type>(t => t == typeof(TestWorkflowTask)))).Returns(task);
            mock.Setup(m => m(It.Is<Type>(t => t == typeof(TestWorkflowTaskAsync)))).Returns(taskAsync);
            return mock;
        }
    }
}
