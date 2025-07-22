using TsysProcessor.Requests.Mappers.ValueGroups;
using TsysProcessor.Requests.Messages;
using TsysProcessor.Requests.Messages.Groups;
using System.Text;
using TsysProcessor.Requests.Mappers.Groups;
using TsysProcessor.Transaction.Context;
using Payment.Messages.Factories.Delegates;
using Payment.Messages.Serializers;
using Payment.Messages;
using Payment.Messages.Mappers;

namespace TsysProcessor.Requests.Mappers
{
    public class SaleMapper : ParentMapper<TsysTransactionContext, SaleMessage>
    {
        public SaleMapper(MapperFactory<TsysTransactionContext> mapperFactory, IStringMessageSerializer messageSerializer) : base(mapperFactory, messageSerializer)
        {}

        public override IAccessibleMessage Map(TsysTransactionContext transactionContext)
        {
            var builder = new StringBuilder();

            return new SaleMessage()
            {
                AccountDataSource = "XXX",
                AcquirerBin = 0,
                CardAcceptorData = MapValueGroup<CardAcceptorDataMapper>(transactionContext, builder),
                CardholderIdentificationData = "XXX",
                CityCode = transactionContext.ProcessorAttributes.CityCode,
                CustomerDataField = "XXX",
                IndustryCode = IndustryCode(transactionContext),
                MarketSpecificDataIndicator = "XXX",
                ReversalCancelDataI = "XXX",
                ReversalIncrementalTransactionId = "XXX",
                TransactionCode = "XXX",
                Group3 = (Group3)MapGroup<Group3Mapper>(transactionContext)
            };
        }

        private string IndustryCode(TsysTransactionContext transactionContext)
        {
            return transactionContext.Merchant.Industry switch
            {
                "RETAIL" => "R",
                "MOTO" => "D",
                _ => "",
            };
        }


    }
}
