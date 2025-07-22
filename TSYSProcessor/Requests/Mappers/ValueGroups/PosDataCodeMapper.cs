using TsysProcessor.Requests.Messages.ValueGroups;
using Payment.Messages;
using TsysProcessor.Transaction.Context;
using Payment.Messages.Mappers;

namespace TsysProcessor.Requests.Mappers.ValueGroups
{
    public class PosDataCodeMapper : Mapper<TsysTransactionContext, PosDataCode>
    {
        public override IAccessibleMessage Map(TsysTransactionContext transactionContext)
        {
            return new PosDataCode()
            {
                CardholderAuthenticationEntity = '2',
                CardholderAuthenticationMethod = '3',
                CardholderPresentData = '4',
                CardInputMode = '5',
                CardPresentData = '6'
            };
        }
    }
}
