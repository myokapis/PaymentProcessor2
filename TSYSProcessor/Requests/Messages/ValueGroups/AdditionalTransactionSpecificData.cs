using Payment.Messages;

namespace TsysProcessor.Requests.Messages.ValueGroups
{
    public class AdditionalTransactionSpecificData : AccessibleMessage<AdditionalTransactionSpecificData>
    {
        public string GroupName { get; } = "091";
        public string? TransactionLinkIdentifier { get; set; }
        public required string MerchantPaymentGatewayId { get; set; }
    }
}
