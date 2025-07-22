using TsysProcessor.Requests.Messages.ValueGroups;
using Payment.Messages;
using Payment.Messages.Mappers;
using TsysProcessor.Transaction.Context;

namespace TsysProcessor.Requests.Mappers.ValueGroups
{
    public class DeveloperInformationMapper : Mapper<TsysTransactionContext, DeveloperInformation>
    {
        public override IAccessibleMessage Map(TsysTransactionContext transactionContext)
        {
            return new DeveloperInformation()
            {
                ApplicationId = "APP1",
                DeveloperId = "Dev1",
                GatewayId = "Gateway1"
            };
        }
    }
}
