using Payment.Messages;
using Payment.Messages.Mappers;
using TsysProcessor.Requests.Messages.ValueGroups;
using TsysProcessor.Transaction.Context;

namespace TsysProcessor.Requests.Mappers.ValueGroups
{
    public class CardAcceptorDataMapper : Mapper<TsysTransactionContext, CardAcceptorData>
    {
        public override IAccessibleMessage Map(TsysTransactionContext transactionContext)
        {
            return new CardAcceptorData()
            {
                // TODO: map fields
            };
        }
    }
}
