using TsysProcessor.Requests.Messages.ValueGroups;
using Payment.Messages;
using TsysProcessor.Transaction.Context;
using Payment.Messages.Mappers;

namespace TsysProcessor.Requests.Mappers.ValueGroups
{
    public class MotoEcommIndicatorMapper : Mapper<TsysTransactionContext, MotoEcommIndicator>
    {
        public override IAccessibleMessage Map(TsysTransactionContext transactionContext)
        {
            return new MotoEcommIndicator();
        }
    }
}
