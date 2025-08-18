using Payment.Processor.Transaction.Model;

namespace Payment.Processor.Transaction.Context
{
    // TODO: should the properties use init instead of set?

    /// <summary>
    /// Describes a transaction context.
    /// </summary>
    /// <typeparam name="TEnvelope">The type of the envelope used in the transaction.</typeparam>
    /// <typeparam name="TAttributes">The type of the processor attributes used in the transaction.</typeparam>
    public class TransactionContext<TEnvelope, TAttributes> : ITransactionContext<TEnvelope, TAttributes>
        where TEnvelope : IEnvelope
        where TAttributes : IProcessorAttributes
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        /// <summary>
        /// The action context derived from the transaction.
        /// </summary>
        public ActionContext ActionContext { get; set; }

        /// <summary>
        /// The card context derived from the transaction.
        /// </summary>
        public CardContext CardContext { get; set; }

        /// <summary>
        /// The card on file context derived from the transaction.
        /// </summary>
        public CardOnFileContext CardOnFileContext { get; set; }

        /// <summary>
        /// The transaction details.
        /// </summary>
        public Details Details { get; set; }

        /// <summary>
        /// The envelope associated with the transaction.
        /// </summary>
        public TEnvelope? Envelope { get; set; }

        /// <summary>
        /// A model describing the merchant participating in the transaction.
        /// </summary>
        public Merchant Merchant { get; set; }

        /// <summary>
        /// The merchant's processor settings and attributes.
        /// </summary>
        public TAttributes ProcessorAttributes { get; set; }

        /// <summary>
        /// The reader context derived from the transaction.
        /// </summary>
        public ReaderContext ReaderContext { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    }
}
