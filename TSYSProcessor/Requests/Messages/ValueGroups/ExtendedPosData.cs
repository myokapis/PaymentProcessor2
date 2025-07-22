using Payment.Messages;

namespace TsysProcessor.Requests.Messages.ValueGroups
{
    public class ExtendedPosData : AccessibleMessage<ExtendedPosData>
    {
        public string GroupName { get; } = "077";
        public int? TransactionStatus { get; set; }
        public int AcceptanceDeviceType { get; set; } = 0;
    }
}
