using TsysProcessor.Responses;
using TsysProcessor.Transaction.Model;
using TsysProcessor.Workflow.Context;

namespace TsysProcessor.Processor.TransactionTasks
{
    /// <summary>
    /// Creates a context object containing values derived from the response.
    /// </summary>
    public class BuildResponseContext : TsysTask
    {
        /// <summary>
        /// Creates an instance of the task.
        /// </summary>
        /// <param name="workflowContext">The workflow context in which the task runs.</param>
        public BuildResponseContext(TsysWorkflowContext workflowContext) : base(workflowContext)
        {
        }

        protected override bool RunActive()
        {
            // TODO: implement the actual code
            var requiresVoiding = false;
            var requiresTimeoutReversal = false;

            WorkflowContext.ResponseContext = new TsysResponseContext()
            {
                AutoVoidModel = BuildAutoVoidMessage(requiresVoiding),
                RequiresTimeoutReversal = requiresTimeoutReversal,
                RequiresVoiding = requiresVoiding,
                TimeoutReversalModel = BuildTimeoutReversalMessage(requiresTimeoutReversal)
            };

            return true;
        }

        private TsysTransaction? BuildAutoVoidMessage(bool requiresVoiding)
        {
            if (!requiresVoiding) return null;

            // TODO: implement the logic. This is placeholder code in order to return a value.
            return WorkflowContext.Transaction;
        }

        private TsysTransaction? BuildTimeoutReversalMessage(bool requiresTimeoutReversal)
        {
            // TODO: implement the logic. This is placeholder code in order to return a value.
            return WorkflowContext.Transaction;
        }
    }
}
