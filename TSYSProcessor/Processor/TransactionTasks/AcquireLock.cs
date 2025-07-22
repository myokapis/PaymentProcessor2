using TsysProcessor.Workflow.Context;

namespace TsysProcessor.Processor.TransactionTasks
{
    public class AcquireLock : TsysTaskAsync
    {
        public AcquireLock(TsysWorkflowContext workflowContext) : base(workflowContext)
        {
        }

        protected override Task<bool> RunActiveAsync()
        {
            // TODO: acquire a lock from zookeeper or other locking service.
            //       if the lock is successfully acquired, then persist the lock key in the tsys context.
            //       if a lock cannot be acquired, then raise an error if one wasn't already raised by the locking service.
            return Task.FromResult(true);
        }
    }
}
