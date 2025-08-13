
using TsysProcessor.Workflow.Context;

namespace TsysProcessor.Processor.TransactionTasks
{
    public class ReleaseLock : TsysTaskAsync
    {
        /// <summary>
        /// Releases the lock held around the transaction.
        /// </summary>
        /// <param name="workflowContext">The workflow context in which the task runs.</param>
        public ReleaseLock(TsysWorkflowContext workflowContext) : base(workflowContext)
        {
        }

        protected override async Task<bool> RunActiveAsync()
        {
            // TODO: decide what to do if no lock handle is found. Need to think
            //       through the use cases that could cause that to occur.
            var lockHandle = WorkflowContext.LockHandle;
            if (lockHandle == null) return await Task.FromResult(true);

            // TODO: release the lock if there is a lock key in the tsys context.
            return await Task.FromResult(true);
        }

        // NOTE: this errored path is required since we must always release the lock.
        protected override async Task<bool> RunErroredAsync()
        {
            // TODO: decide what to do if no lock handle is found. Need to think
            //       through the use cases that could cause that to occur.
            var lockHandle = WorkflowContext.LockHandle;
            if (lockHandle == null) return await Task.FromResult(true);

            // TODO: release the lock if there is a lock key in the tsys context.
            return await Task.FromResult(false);
        }
    }
}
