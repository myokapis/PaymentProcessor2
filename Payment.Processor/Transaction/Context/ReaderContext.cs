using Payment.Processor.Enums;

namespace Payment.Processor.Transaction.Context
{
    /// <summary>
    /// Describes a reader and its capabilities.
    /// </summary>
    public class ReaderContext : IReaderContext
    {
        /// <summary>
        /// Creates an instance of the reader context.
        /// </summary>
        public ReaderContext() { }

        /// <summary>
        /// True if the reader is capable of reading a card's chip via contact with the card.
        /// </summary>
        public bool EmvCapable { get; init; }

        /// <summary>
        /// True if the reader is capable of reading a card's magnetic stripe via contact with the card.
        /// </summary>
        public bool MsrCapable { get; init; }

        /// <summary>
        /// True if the reader is capable of reading a card's chip without contact with the card.
        /// </summary>
        public bool NfcCapable { get; init; }

        /// <summary>
        /// True if the EMV contact capability is enabled.
        /// </summary>
        public bool EmvEnabled { get; init; }

        /// <summary>
        /// True if the magnetic stripe capability is enabled.
        /// </summary>
        public bool MsrEnabled { get; init; }

        /// <summary>
        /// True if the contactless EMV capability is enabled.
        /// </summary>
        public bool NfcEnabled { get; init; }

        /// <summary>
        /// The reader's serial number.
        /// </summary>
        public required string SerialNumber { get; init; }

        /// <summary>
        /// An enumeration describing the make and model of the reader.
        /// </summary>
        public required ReaderType Type { get; init; }
    }
}
