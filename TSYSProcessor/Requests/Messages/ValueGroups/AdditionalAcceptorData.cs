using Payment.Messages.Attributes.Serialization;
using Payment.Messages;

namespace TsysProcessor.Requests.Messages.ValueGroups
{
    public class AdditionalAcceptorData : AccessibleMessage<AdditionalAcceptorData>
    {
        public string GroupName { get; } = "088";

        //[Serialization(Terminator = Constants.FS)]
        public required string StreetAddress { get; set; }

        //[Serialization(Terminator = Constants.FS)]
        public required string CustomerServicePhoneNumber { get; set; }

        //[Serialization(Terminator = Constants.FS)]
        public required string PhoneNumber { get; set; }

        //[Serialization(Terminator = Constants.FS)]
        public string? UrlAddress { get; set; }
    }
}
