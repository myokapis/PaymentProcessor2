using Payment.Messages;

namespace TsysProcessor.Requests.Messages.ValueGroups
{
    public class SpendQualifiedIndicator : AccessibleMessage<SpendQualifiedIndicator>
    {
        public string GroupName { get; } = "061";
    }
}
