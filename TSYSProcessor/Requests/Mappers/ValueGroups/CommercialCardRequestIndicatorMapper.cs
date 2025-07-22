using TsysProcessor.Requests.Messages.ValueGroups;
using Payment.Messages;
using Payment.Messages.Mappers;
using TsysProcessor.Transaction.Context;

namespace TsysProcessor.Requests.Mappers.ValueGroups
{
    public class CommercialCardRequestIndicatorMapper : Mapper<TsysTransactionContext, CommercialCardRequestIndicator>
    {
        public override IAccessibleMessage Map(TsysTransactionContext transactionContext)
        {
            return new CommercialCardRequestIndicator();
        }
    }
}
