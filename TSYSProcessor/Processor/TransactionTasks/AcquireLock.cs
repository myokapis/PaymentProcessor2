using TsysProcessor.Workflow.Context;

namespace TsysProcessor.Processor.TransactionTasks
{
    /// <summary>
    /// Attempts to acquire a lock around the current transaction.
    /// </summary>
    public class AcquireLock : TsysTaskAsync
    {
        /// <summary>
        /// Creates an instance of the task.
        /// </summary>
        /// <param name="workflowContext">The workflow context in which the task runs.</param>
        public AcquireLock(TsysWorkflowContext workflowContext) : base(workflowContext)
        {
        }

        protected override Task<bool> RunActiveAsync()
        {
            // TODO: fill out the logic for creating a unique lock handle for the transaction.
            var lockHandle = "";

            // TODO: acquire a lock from zookeeper.
            //       if the lock is successfully acquired, then persist the lock key in the tsys context.
            //       if a lock cannot be acquired, then raise an error if one wasn't already raised by the locking service.
            WorkflowContext.LockHandle = lockHandle;
            return Task.FromResult(true);
        }
    }
}
