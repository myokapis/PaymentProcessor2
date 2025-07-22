using Payment.Messages;

namespace TsysProcessor.Requests.Messages.ValueGroups
{
    public class PosEnvironmentIndicator : AccessibleMessage<PosEnvironmentIndicator>
    {
        public string GroupName { get; } = "071";
        public char? EnvironmentIndicator { get; set; }
    }
}
