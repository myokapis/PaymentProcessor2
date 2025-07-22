using Payment.Messages;

namespace TsysProcessor.Requests.Messages.ValueGroups
{
    public class FraudEnhancedData : AccessibleMessage<FraudEnhancedData>
    {
        public string GroupName { get; } = "068";
        public char RegisteredUserIndicator { get; } = 'N';
        public string LastProfileDateChange { get; } = "00000000";
    }
}
