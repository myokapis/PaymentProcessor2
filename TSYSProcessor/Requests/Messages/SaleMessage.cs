using Payment.Messages;
using TsysProcessor.Requests.Messages.Groups;

namespace TsysProcessor.Requests.Messages
{
    public class SaleMessage : AccessibleMessage<SaleMessage>
    {
        public string RecordFormat { get; set; } = "D";
        public int ApplicationType { get; set; } = 4;
        public string MessageDelimiter { get; set; } = ".";
        public int AcquirerBin { get; set; }
        public int MerchantNumber { get; set; }
        public int StoreNumber { get; set; }
        public int TerminalNumber { get; set; }
        public string DeviceCode { get; set; } = "G";
        public required string IndustryCode { get; set; }
        public int CurrencyCode { get; set; } = 840;
        public int CountryCode { get; set; } = 840;
        public required string CityCode { get; set; }
        public int LanguageIndicator { get; set; } = 0;
        public int TimeZoneDifferential { get; set; }
        public int MerchantCategoryCode { get; set; }
        public string RequestedAci { get; set; } = "Y";
        public int TransactionSequenceNumber { get; set; } = 1;
        public required string TransactionCode { get; set; }
        public string CardholderIdentificationCode { get; set; } = "@";
        public required string AccountDataSource { get; set; }
        public required string CustomerDataField { get; set; }
        public required string CardholderIdentificationData { get; set; }
        public int ReceivingInstitutionId { get; set; }
        public int TransactionAmount { get; set; }
        public int SecondaryAmount { get; set; }
        public required string MarketSpecificDataIndicator { get; set; }
        public required string CardAcceptorData { get; set; }
        public required string ReversalIncrementalTransactionId { get; set; }
        public required string ReversalCancelDataI { get; set; }
        public required Group3 Group3 { get; set; }
    }
}
