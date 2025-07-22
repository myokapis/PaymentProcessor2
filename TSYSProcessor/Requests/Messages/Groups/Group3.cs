using Payment.Messages.Attributes.Serialization;
using Payment.Messages;

namespace TsysProcessor.Requests.Messages.Groups
{
    public class Group3 : AccessibleMessage<Group3>
    {
        public required string CommercialCardRequestIndicator { get; set; }
        public string Cvv { get; set; } = "";
        public required string ChipConditionCode { get; set; }
        public required string MotoEcommIndicator { get; set; }
        public required string DeveloperInformation { get; set; }
        public required string AdditionalAmounts { get; set; }
        public required string TransactionFeeAmount { get; set; }
        public required string PartialAuthIndicator { get; set; }
        public string AmexAdditionalData { get; set; } = "";
        public string ExtendedAvsData { get; set; } = "";
        public required string CardProductCode { get; set; }

        [Serialization(Masked = true, MaskChar = '&')]
        public required string TerminalAuthentication { get; set; }
        public required string IntegratedChipCard { get; set; }
        public required string MessageReasonCode { get; set; }
        public required string MasterCardPaymentIndicators { get; set; }
        public required string SpendQualifiedIndicator { get; set; }
        public required string MCAuthIndicator { get; set; }
        public required string FraudEnhancedData { get; set; }
        public required string PosEnvironmentIndicator { get; set; }
        public required string MCAuthenticationData { get; set; }
        public required string TransactionIntegrityClass { get; set; }
        public required string ExtendedPosData { get; set; }
        public required string CitMitIndicator { get; set; }

        //[Serialization(Terminator = Constants.GS)]
        public required string AdditionalAcceptorData { get; set; }
        public required string AdditionalTransactionSpecificData { get; set; }
        public required string PosDataCode { get; set; }
    }
}
