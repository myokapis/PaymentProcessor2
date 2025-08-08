using Payment.Processor.Enums;
using Payment.Processor.Extensions;
using Payment.Processor.Transaction.Context;
using Payment.Processor.Transaction.Model;

namespace Payment.Processor.Builders
{
    /// <summary>
    /// Builds a reader context.
    /// </summary>
    public class ReaderContextBuilder : IBuilder<ReaderContext>
    {
        /// <summary>
        /// Creates an instance of the reader context builder.
        /// </summary>
        public ReaderContextBuilder() { }

        /// <summary>
        /// Builds a reader context from a transaction model.
        /// </summary>
        /// <param name="transaction">The transaction model providing the data.</param>
        /// <returns>An instance of a reader context corresponding to the data in the transaction model.</returns>
        public ReaderContext Build(ITransactionModel transaction)
        {
            var reader = transaction.Details.Reader;
            var readerType = ReaderType.UNKNOWN.Parse(reader.Type);

            return new ReaderContext()
            {
                EmvCapable = EmvCapable(readerType),
                EmvEnabled = reader.EmvEnabled,
                MsrCapable = MsrCapable(readerType),
                MsrEnabled = reader.MsrEnabled,
                NfcCapable = NfcCapable(readerType),
                NfcEnabled = reader.NfcEnabled,
                SerialNumber = reader.SerialNumber,
                Type = readerType
            };
        }

        protected static IEnumerable<ReaderType> EmvCapableReaders = [
            ReaderType.B200,
            ReaderType.B250,
            ReaderType.B350,
            ReaderType.B500,
            ReaderType.M010,
            ReaderType.WALKER
        ];

        protected static IEnumerable<ReaderType> MsrCapableReaders = [
            ReaderType.A250,
            ReaderType.B200,
            ReaderType.B250,
            ReaderType.B350,
            ReaderType.B500,
            ReaderType.BTMAG,
            ReaderType.IDTECH,
            ReaderType.M010,
            ReaderType.RAMBLER,
            ReaderType.UNENCRYPTED,
            ReaderType.WALKER
        ];

        protected static IEnumerable<ReaderType> NfcCapableReaders = [
            ReaderType.B250,
            ReaderType.B350,
            ReaderType.M010
        ];

        protected static bool EmvCapable(ReaderType readerType)
        {
            return EmvCapableReaders.Any(r => r == readerType);
        }

        protected static bool MsrCapable(ReaderType readerType)
        {
            return MsrCapableReaders.Any(r => r == readerType);
        }

        protected static bool NfcCapable(ReaderType readerType)
        {
            return NfcCapableReaders.Any(r => r == readerType);
        }
    }
}
