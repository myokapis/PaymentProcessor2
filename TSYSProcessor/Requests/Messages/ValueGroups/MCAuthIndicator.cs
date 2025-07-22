using Payment.Messages;

namespace TsysProcessor.Requests.Messages.ValueGroups
{
    public class MCAuthIndicator : AccessibleMessage<MCAuthIndicator>
    {
        public string GroupName { get; } = "067";
        public char? AuthIndicator { get; set; }
    }
}
