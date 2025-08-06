using Payment.Workflow;
using Payment.Workflow.Factories.Delegates;
using TsysProcessor.Processor.Transaction;
using TsysProcessor.Processor.TransactionSteps;
using TsysProcessor.Processor.TransactionTasks;
using TsysProcessor.Workflow.Context;

namespace TsysProcessor.Processor
{
    public class TsysTransactionRunner : WorkflowRunner<TsysWorkflowContext>
    {
        public TsysTransactionRunner(WorkflowTaskFactory workflowTaskFactory, TsysWorkflowContext workflowContext) :
            base(workflowTaskFactory, workflowContext)
        {
        }

        protected override void HandleException(Exception exception)
        {
            // TODO: log error here
        }

        protected override async Task RunWorkflowTasks()
        {
            await RunWorkflowTaskAsync<AcquireLock>();
            await RunWorkflowTaskAsync<BuildTransactionContext>();
            RunWorkflowTask<BuildMessage>();
            RunWorkflowTask<SerializeMessage>();
            await RunWorkflowTaskAsync<SaveMessage>();
            await RunWorkflowTaskAsync<SendMessage>();
            RunWorkflowTask<ParseResponse>();
            RunWorkflowTask<BuildResponseEnvelope>();
            await RunWorkflowTaskAsync<SaveResponse>();
            await RunWorkflowTaskAsync<ReleaseLock>();
        }
    }
}
