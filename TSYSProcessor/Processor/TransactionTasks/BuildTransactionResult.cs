using System.Transactions;
using Payment.Processor.Transaction.Result;
using TsysProcessor.Workflow.Context;

namespace TsysProcessor.Processor.TransactionTasks
{
    /// <summary>
    /// Builds a transaction result for the processed transaction.
    /// </summary>
    public class BuildTransactionResult : TsysTask
    {
        /// <summary>
        /// Constructs an instance of the task.
        /// </summary>
        /// <param name="workflowContext">The workflow context in which the task runs.</param>
        public BuildTransactionResult(TsysWorkflowContext workflowContext) : base(workflowContext)
        {
        }

        protected override bool RunActive()
        {
            var transactionId = WorkflowContext.Transaction?.Details?.Id;
            if (transactionId == null) throw new ArgumentNullException(nameof(WorkflowContext.Transaction.Details.Id));

            // TODO: build a transaction result to be enqueued
            WorkflowContext.TransactionResult = new ResultMessage()
            { 
                Id = transactionId,
                Result = Payment.Processor.Enums.TransactionResult.NotApproved // set this value based on what happened
            };

            return true;
        }

        protected override bool RunErrored()
        {
            var transactionId = WorkflowContext.Transaction?.Details?.Id;
            if (transactionId == null) throw new ArgumentNullException(nameof(WorkflowContext.Transaction.Details.Id));

            // TODO: build a transaction result to be enqueued.
            //       a transaction result must always be returned even if an error occurred during processing.
            WorkflowContext.TransactionResult = new ResultMessage()
            {
                Id = transactionId,
                Result = Payment.Processor.Enums.TransactionResult.ProcessingError // set this value based on what happened
            };

            return false;
        }
    }
}
