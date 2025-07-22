using Payment.Messages;

namespace TsysProcessor.Requests.Messages.ValueGroups
{
    public class DeveloperInformation : AccessibleMessage<DeveloperInformation>
    {
        public string GroupName { get; } = "020";
        public required string DeveloperId { get; set; }
        public required string ApplicationId { get; set; }
        public required string GatewayId { get; set; }
    }
}
