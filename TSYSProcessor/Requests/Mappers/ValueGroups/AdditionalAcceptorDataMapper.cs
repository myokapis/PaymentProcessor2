using Payment.Messages;
using Payment.Messages.Mappers;
using TsysProcessor.Requests.Messages.ValueGroups;
using TsysProcessor.Transaction.Context;

namespace TsysProcessor.Requests.Mappers.ValueGroups
{
    public class AdditionalAcceptorDataMapper : Mapper<TsysTransactionContext, AdditionalAcceptorData>
    {
        public override IAccessibleMessage Map(TsysTransactionContext transactionContext)
        {
            return new AdditionalAcceptorData()
            {
                CustomerServicePhoneNumber = "8885551212",
                PhoneNumber = "8885551212",
                StreetAddress = "1444 First St."
            };
        }
    }
}
