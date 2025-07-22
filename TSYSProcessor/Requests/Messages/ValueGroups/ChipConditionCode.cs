using Payment.Messages;

namespace TsysProcessor.Requests.Messages.ValueGroups
{
    public class ChipConditionCode : AccessibleMessage<ChipConditionCode>
    {
        public string GroupName { get; } = "011";
        public int Code { get; set; }
    }
}
