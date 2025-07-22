using Payment.Processor.Enums;

namespace Payment.Processor.Transaction.Context
{
    public class ReaderContext : IReaderContext
    {
        public ReaderContext() { }

        public bool EmvCapable { get; init; }
        public bool MsrCapable { get; init; }
        public bool NfcCapable { get; init; }
        public bool EmvEnabled { get; init; }
        public bool MsrEnabled { get; init; }
        public bool NfcEnabled { get; init; }
        public required string SerialNumber { get; init; }
        public required ReaderType Type { get; init; }
    }
}
