using TsysProcessor.Requests.Messages.ValueGroups;
using Payment.Messages;
using Payment.Messages.Mappers;
using TsysProcessor.Transaction.Context;

namespace TsysProcessor.Requests.Mappers.ValueGroups
{
    public class ExtendedPosDataMapper : Mapper<TsysTransactionContext, ExtendedPosData>
    {
        public override IAccessibleMessage Map(TsysTransactionContext transactionContext)
        {
            return new ExtendedPosData();
        }
    }
}
