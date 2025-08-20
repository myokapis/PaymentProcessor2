using Payment.Processor.Enums;

namespace Payment.Processor.Transaction.Context
{
    /// <summary>
    /// Describes a reader and its capabilities.
    /// </summary>
    public interface IReaderContext : IContext
    {
        /// <summary>
        /// True if the reader is capable of reading a card's chip via contact with the card.
        /// </summary>
        bool EmvCapable { get; init; }

        /// <summary>
        /// True if the reader is capable of reading a card's magnetic stripe via contact with the card.
        /// </summary>
        bool MsrCapable { get; init; }

        /// <summary>
        /// True if the reader is capable of reading a card's chip without contact with the card.
        /// </summary>
        bool NfcCapable { get; init; }

        /// <summary>
        /// True if the EMV contact capability is enabled.
        /// </summary>
        bool EmvEnabled { get; init; }

        /// <summary>
        /// True if the magnetic stripe capability is enabled.
        /// </summary>
        bool MsrEnabled { get; init; }

        /// <summary>
        /// True if the contactless EMV capability is enabled.
        /// </summary>
        bool NfcEnabled { get; init; }

        /// <summary>
        /// The reader's serial number.
        /// </summary>
        string SerialNumber { get; init; }

        /// <summary>
        /// An enumeration describing the make and model of the reader.
        /// </summary>
        ReaderType Type { get; init; }
    }
}
