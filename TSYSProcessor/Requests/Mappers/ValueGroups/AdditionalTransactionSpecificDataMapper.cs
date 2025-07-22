using TsysProcessor.Requests.Messages.ValueGroups;
using Payment.Messages;
using Payment.Messages.Mappers;
using TsysProcessor.Transaction.Context;

namespace TsysProcessor.Requests.Mappers.ValueGroups
{
    public class AdditionalTransactionSpecificDataMapper : Mapper<TsysTransactionContext, AdditionalTransactionSpecificData>
    {
        public override IAccessibleMessage Map(TsysTransactionContext transactionContext)
        {
            return new AdditionalTransactionSpecificData()
            {
                MerchantPaymentGatewayId = "MPGID",
                TransactionLinkIdentifier = "TLID"
            };
        }
    }
}
