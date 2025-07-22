using Payment.Workflow.Interfaces;

namespace Tests.Payment.Workflow
{
    public class IWorkflowTaskTests
    {
        [Fact]
        public void Run()
        {
            var testTask = (IWorkflowTask)new EmptyWorkflowTask();
            Assert.Throws<NotImplementedException>(() => { testTask.Run(); });
        }

        [Fact]
        public async Task RunAsync()
        {
            var testTask = (IWorkflowTask)new EmptyWorkflowTask();
            await Assert.ThrowsAsync<NotImplementedException>(async () => { await testTask.RunAsync(); });
        }

        public class EmptyWorkflowTask : IWorkflowTask { }
    }
}
