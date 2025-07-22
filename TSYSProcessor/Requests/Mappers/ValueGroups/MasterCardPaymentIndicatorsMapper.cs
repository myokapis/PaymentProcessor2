using TsysProcessor.Requests.Messages.ValueGroups;
using Payment.Messages;
using Payment.Messages.Mappers;
using TsysProcessor.Transaction.Context;

namespace TsysProcessor.Requests.Mappers.ValueGroups
{
    public class MasterCardPaymentIndicatorsMapper : Mapper<TsysTransactionContext, MastercardPaymentIndicators>
    {
        public override IAccessibleMessage Map(TsysTransactionContext transactionContext)
        {
            return new MastercardPaymentIndicators()
            {
                DeviceType = "DVT001"
            };
        }
    }
}
