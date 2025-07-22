using Payment.Messages;

namespace TsysProcessor.Requests.Messages.ValueGroups
{
    public class CommercialCardRequestIndicator : AccessibleMessage<CommercialCardRequestIndicator>
    {
        public string GroupName { get; } = "001";
        public string Indicator { get; } = "!010";
    }
}
