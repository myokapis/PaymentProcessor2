using TsysProcessor.Requests.Mappers.ValueGroups;
using System.Text;
using TsysProcessor.Requests.Messages.Groups;
using TsysProcessor.Transaction.Context;
using Payment.Messages.Mappers;
using Payment.Messages;
using Payment.Messages.Factories.Delegates;
using Payment.Messages.Serializers;

namespace TsysProcessor.Requests.Mappers.Groups
{
    public class Group3Mapper : ParentMapper<TsysTransactionContext, Group3>
    {
        public Group3Mapper(MapperFactory<TsysTransactionContext> mapperFactory, IStringMessageSerializer messageSerializer) : base(mapperFactory, messageSerializer)
        { }

        public override IAccessibleMessage Map(TsysTransactionContext transactionContext)
        {
            var builder = new StringBuilder();

            return new Group3()
            {
                AdditionalAcceptorData = MapValueGroup<AdditionalAcceptorDataMapper>(transactionContext, builder),
                AdditionalAmounts = MapValueGroup<AdditionalAmountsMapper>(transactionContext, builder),
                CardProductCode = MapValueGroup<CardProductCodeMapper>(transactionContext, builder),
                ChipConditionCode = MapValueGroup<ChipConditionCodeMapper>(transactionContext, builder),
                CitMitIndicator = MapValueGroup<CitMitIndicatorMapper>(transactionContext, builder),
                CommercialCardRequestIndicator = MapValueGroup<CommercialCardRequestIndicatorMapper>(transactionContext, builder),
                DeveloperInformation = MapValueGroup<DeveloperInformationMapper>(transactionContext, builder),
                ExtendedPosData = MapValueGroup<ExtendedPosDataMapper>(transactionContext, builder),
                FraudEnhancedData = MapValueGroup<FraudEnhancedDataMapper>(transactionContext, builder),
                IntegratedChipCard = "ICC Data",
                AdditionalTransactionSpecificData = MapValueGroup<AdditionalTransactionSpecificDataMapper>(transactionContext, builder),
                MasterCardPaymentIndicators = MapValueGroup<MasterCardPaymentIndicatorsMapper>(transactionContext, builder),
                MCAuthenticationData = MapValueGroup<MCAuthenticationDataMapper>(transactionContext, builder),
                MCAuthIndicator = MapValueGroup<MCAuthIndicatorMapper>(transactionContext, builder),
                MessageReasonCode = "REASON",
                MotoEcommIndicator = MapValueGroup<MotoEcommIndicatorMapper>(transactionContext, builder),
                PartialAuthIndicator = MapValueGroup<PartialAuthIndicatorMapper>(transactionContext, builder),
                PosDataCode = MapValueGroup<PosDataCodeMapper>(transactionContext, builder),
                PosEnvironmentIndicator = MapValueGroup<PosEnvironmentIndicatorMapper>(transactionContext, builder),
                SpendQualifiedIndicator = MapValueGroup<SpendQualifiedIndicatorMapper>(transactionContext, builder),
                TerminalAuthentication = "TERM AUTH",
                TransactionFeeAmount = MapValueGroup<TransactionFeeAmountMapper>(transactionContext, builder),
                TransactionIntegrityClass = MapValueGroup<TransactionIntegrityClassMapper>(transactionContext, builder)
            };
        }
    }
}
