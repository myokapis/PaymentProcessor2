using Payment.Messages;

namespace TsysProcessor.Requests.Messages.ValueGroups
{
    public class MastercardPaymentIndicators : AccessibleMessage<MastercardPaymentIndicators>
    {
        public string GroupName { get; } = "060";
        public int BypassMobileDomainServer { get; } = 0;
        public required string DeviceType { get; set; }
    }
}
