using Payment.Messages;

namespace TsysProcessor.Requests.Messages.ValueGroups
{
    public class AdditionalAmounts : AccessibleMessage<AdditionalAmounts>
    {
        public string GroupName { get; } = "022";
        // TODO: implement remaining fields later when they are required
    }
}
