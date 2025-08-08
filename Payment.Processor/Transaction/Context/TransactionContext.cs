using Payment.Processor.Transaction.Model;

namespace Payment.Processor.Transaction.Context
{
    /// <summary>
    /// Describes a transaction context.
    /// </summary>
    /// <typeparam name="TEnvelope">The type of the envelope used in the transaction.</typeparam>
    /// <typeparam name="TAttributes">The type of the processor attributes used in the transaction.</typeparam>
    public class TransactionContext<TEnvelope, TAttributes> : ITransactionContext<TEnvelope, TAttributes>
        where TEnvelope : IEnvelope
        where TAttributes : IProcessorAttributes
    {
        /// <summary>
        /// The action context derived from the transaction.
        /// </summary>
        public required ActionContext ActionContext { get; set; }

        /// <summary>
        /// The card context derived from the transaction.
        /// </summary>
        public required CardContext CardContext { get; set; }

        /// <summary>
        /// The card on file context derived from the transaction.
        /// </summary>
        public required CardOnFileContext CardOnFileContext { get; set; }

        /// <summary>
        /// The transaction details.
        /// </summary>
        public required Details Details { get; set; }

        /// <summary>
        /// The envelope associated with the transaction.
        /// </summary>
        public TEnvelope? Envelope { get; set; }

        /// <summary>
        /// A model describing the merchant participating in the transaction.
        /// </summary>
        public required Merchant Merchant { get; set; }

        /// <summary>
        /// The merchant's processor settings and attributes.
        /// </summary>
        public required TAttributes ProcessorAttributes { get; set; }

        /// <summary>
        /// The reader context derived from the transaction.
        /// </summary>
        public required ReaderContext ReaderContext { get; set; }
    }
}
