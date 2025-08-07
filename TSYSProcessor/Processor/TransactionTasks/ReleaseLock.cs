
using TsysProcessor.Workflow.Context;

namespace TsysProcessor.Processor.TransactionTasks
{
    internal class ReleaseLock : TsysTaskAsync
    {
        public ReleaseLock(TsysWorkflowContext workflowContext) : base(workflowContext)
        {
        }

        protected override async Task<bool> RunActiveAsync()
        {
            // TODO: release the lock if there is a lock key in the tsys context.
            return await Task.FromResult(true);
        }

        protected override async Task<bool> RunErroredAsync()
        {
            // TODO: release the lock if there is a lock key in the tsys context.
            return await Task.FromResult(false);
        }
    }
}
