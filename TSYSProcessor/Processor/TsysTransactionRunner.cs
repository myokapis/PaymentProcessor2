using Serilog;
using Payment.Workflow;
using Payment.Workflow.Factories.Delegates;
using TsysProcessor.Processor.Transaction;
using TsysProcessor.Processor.TransactionSteps;
using TsysProcessor.Processor.TransactionTasks;
using TsysProcessor.Workflow.Context;

namespace TsysProcessor.Processor
{
    /// <summary>
    /// A workflow task runner that runs a set of sequential tasks within a TSYS-specific workflow context.
    /// </summary>
    public class TsysTransactionRunner : WorkflowRunner<TsysWorkflowContext>
    {
        /// <summary>
        /// Creates an instance on the task runner.
        /// </summary>
        /// <param name="workflowTaskFactory">A factory for creating instances of tasks on demand.</param>
        /// <param name="workflowContext">The workflow context in which the task runs.</param>
        public TsysTransactionRunner(WorkflowTaskFactory workflowTaskFactory, TsysWorkflowContext workflowContext) :
            base(workflowTaskFactory, workflowContext)
        {
        }

        protected override void HandleException(Exception exception)
        {
            // TODO: log error here with trace values
            Log.Error(exception, "An exception occurred in the TSYS transaction runner.");
        }

        // TODO: ensure documentation matches this set of tasks

        /// <summary>
        /// Runs a set of tasks sequentially.
        /// </summary>
        /// <returns>A task without a result.</returns>
        protected override async Task RunWorkflowTasks()
        {
            await RunWorkflowTaskAsync<AcquireLock>();
            await RunWorkflowTaskAsync<BuildTransactionContext>();
            RunWorkflowTask<BuildMessage>();
            RunWorkflowTask<SerializeMessage>();
            await RunWorkflowTaskAsync<SaveMessage>();
            await RunWorkflowTaskAsync<SendMessage>();
            RunWorkflowTask<ParseResponse>();
            RunWorkflowTask<BuildResponseContext>();
            RunWorkflowTask<BuildResponseEnvelope>();
            await RunWorkflowTaskAsync<SaveResponse>();
            RunWorkflowTask<BuildTransactionResult>();
            await RunWorkflowTaskAsync<ReleaseLock>();
        }
    }
}
