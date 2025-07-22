using TsysProcessor.Requests.Messages.ValueGroups;
using TsysProcessor.Transaction.Context;
using Payment.Messages;
using Payment.Messages.Mappers;

namespace TsysProcessor.Requests.Mappers.ValueGroups
{
    public class MCAuthIndicatorMapper : Mapper<TsysTransactionContext, MCAuthIndicator>
    {
        public override IAccessibleMessage Map(TsysTransactionContext transactionContext)
        {
            // TODO: set the real values
            return new MCAuthIndicator()
            {
                AuthIndicator = 'Z'
            };
        }
    }
}
