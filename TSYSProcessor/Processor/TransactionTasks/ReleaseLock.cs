
using TsysProcessor.Workflow.Context;

namespace TsysProcessor.Processor.TransactionTasks
{
    internal class ReleaseLock : TsysTaskAsync
    {
        public ReleaseLock(TsysWorkflowContext workflowContext) : base(workflowContext)
        {
        }

        protected override Task<bool> RunActiveAsync()
        {
            // TODO: release the lock if there is a lock key in the tsys context.
            return Task.FromResult(true);
        }

        protected override Task<bool> RunErroredAsync()
        {
            // TODO: release the lock if there is a lock key in the tsys context.
            return Task.FromResult(false);
        }
    }
}
