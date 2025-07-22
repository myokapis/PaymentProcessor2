using Payment.Messages;

namespace TsysProcessor.Requests.Messages.ValueGroups
{
    public class MCAuthenticationData : AccessibleMessage<MCAuthenticationData>
    {
        public string GroupName { get; } = "072";
        public string EcommerceSLI { get; } = "210";
    }
}
