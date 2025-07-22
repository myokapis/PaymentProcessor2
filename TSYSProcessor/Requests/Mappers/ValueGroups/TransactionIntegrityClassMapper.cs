using TsysProcessor.Requests.Messages.ValueGroups;
using Payment.Messages;
using TsysProcessor.Transaction.Context;
using Payment.Messages.Mappers;

namespace TsysProcessor.Requests.Mappers.ValueGroups
{
    public class TransactionIntegrityClassMapper : Mapper<TsysTransactionContext, TransactionIntegrityClass>
    {
        public override IAccessibleMessage Map(TsysTransactionContext transactionContext)
        {
            return new TransactionIntegrityClass();
        }
    }
}
