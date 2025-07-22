using Payment.Messages;

namespace TsysProcessor.Requests.Messages.ValueGroups
{
    public class PosDataCode : AccessibleMessage<PosDataCode>
    {
        public string GroupName { get; } = "027";
        public char? TerminalCardDataInputCapability { get; set; }
        public char TerminalCardholderAuthenticationCapability { get; set; } = '0';
        public char TerminalCardCaptureCapability { get; set; } = '0';
        public char TerminalOperatingEnvironment { get; set; } = 'P';
        public required char CardholderPresentData { get; set; }
        public required char CardPresentData { get; set; }
        public required char CardInputMode { get; set; }
        public required char CardholderAuthenticationMethod { get; set; }
        public required char CardholderAuthenticationEntity { get; set; }
        public char CardDataOutputCapability { get; set; } = '1';
        public char TerminalDataOutputCapability { get; set; } = '4';
        public char PinCaptureCapability { get; set; } = '0';
    }
}
