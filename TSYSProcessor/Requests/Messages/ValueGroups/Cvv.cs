using Payment.Messages;

namespace TsysProcessor.Requests.Messages.ValueGroups
{
    public class Cvv : AccessibleMessage<Cvv>
    {
        public string GroupName { get; set; } = "007";
        public int CvvPresenceIndicator { get; set; }
        public int CvvResponseCodeFlag { get; set; }
        public string CvvCode { get; set; } = "";
    }
}
