using Payment.Messages;
using Payment.Messages.Mappers;
using TsysProcessor.Requests.Messages.ValueGroups;
using TsysProcessor.Transaction.Context;

namespace TsysProcessor.Requests.Mappers.ValueGroups
{
    public class AdditionalAmountsMapper : Mapper<TsysTransactionContext, AdditionalAmounts>
    {
        public override IAccessibleMessage Map(TsysTransactionContext transactionContext)
        {
            return new AdditionalAmounts();
        }
    }
}
