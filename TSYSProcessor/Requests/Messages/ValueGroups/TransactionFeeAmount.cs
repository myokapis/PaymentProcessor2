using Payment.Messages;

namespace TsysProcessor.Requests.Messages.ValueGroups
{
    public class TransactionFeeAmount : AccessibleMessage<TransactionFeeAmount>
    {
        public string GroupName { get; } = "025";
        public char DebitCreditIndicator { get; } = 'D';
        public int Amount { get; set; }
    }
}
