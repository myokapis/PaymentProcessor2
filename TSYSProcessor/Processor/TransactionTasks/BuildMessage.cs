using Payment.Messages.Factories.Delegates;
using TsysProcessor.Processor.TransactionTasks;
using TsysProcessor.Requests.Mappers;
using TsysProcessor.Transaction.Context;
using TsysProcessor.Workflow.Context;

namespace TsysProcessor.Processor.Transaction
{
    /// <summary>
    /// Builds a message to be sent to the TSYS payment processor.
    /// </summary>
    public class BuildMessage : TsysTask
    {
        protected readonly MapperFactory<TsysTransactionContext> mapperFactory;

        /// <summary>
        /// Creates and instance of the task.
        /// </summary>
        /// <param name="workflowContext">The workflow context in which the task runs.</param>
        /// <param name="mapperFactory">A factory for creating mappers.</param>
        public BuildMessage(TsysWorkflowContext workflowContext, MapperFactory<TsysTransactionContext> mapperFactory) : base(workflowContext)
        {
            this.mapperFactory = mapperFactory;
        }

        protected override bool RunActive()
        {
            var transactionContext = WorkflowContext.TransactionContext;
            if (transactionContext == null) throw new ArgumentNullException("Transaction is required.");

            var mapperType = GetMapperType(transactionContext);
            var mapper = mapperFactory(mapperType);
            WorkflowContext.RequestMessage = mapper.Map(transactionContext);
            return true;
        }

        private Type GetMapperType(TsysTransactionContext transactionContext)
        {
            // TODO: add logic to select the mapper type based on the transaction details
            return typeof(SaleMapper);
        }
    }
}
