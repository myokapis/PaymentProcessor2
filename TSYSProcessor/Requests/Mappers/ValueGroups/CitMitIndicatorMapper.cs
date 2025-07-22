using Payment.Messages;
using Payment.Messages.Mappers;
using TsysProcessor.Requests.Messages.ValueGroups;
using TsysProcessor.Transaction.Context;

namespace TsysProcessor.Requests.Mappers.ValueGroups
{
    public class CitMitIndicatorMapper : Mapper<TsysTransactionContext, CitMitIndicator>
    {
        public override IAccessibleMessage Map(TsysTransactionContext transactionContext)
        {
            return new CitMitIndicator()
            {
                Indicator = "M101"
            };
        }
    }
}
