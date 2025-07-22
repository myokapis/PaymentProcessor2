using Payment.Messages;

namespace TsysProcessor.Requests.Messages.ValueGroups
{
    public class CardProductCode : AccessibleMessage<CardProductCode>
    {
        public string GroupName { get; } = "034";
    }
}
