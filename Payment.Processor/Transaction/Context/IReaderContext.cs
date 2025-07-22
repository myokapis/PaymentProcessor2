using Payment.Processor.Enums;

namespace Payment.Processor.Transaction.Context
{
    public interface IReaderContext : IContext
    {
        bool EmvCapable { get; init; }
        bool MsrCapable { get; init; }
        bool NfcCapable { get; init; }
        bool EmvEnabled { get; init; }
        bool MsrEnabled { get; init; }
        bool NfcEnabled { get; init; }
        string SerialNumber { get; init; }
        ReaderType Type { get; init; }
    }
}
