using Payment.Processor.Transaction.Model.V1;

namespace Payment.Processor.Transaction.Context.V1
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
        public ActionContext ActionContext { get; init; }

        /// <summary>
        /// The card context derived from the transaction.
        /// </summary>
        public CardContext CardContext { get; init; }

        /// <summary>
        /// The card on file context derived from the transaction.
        /// </summary>
        public CardOnFileContext CardOnFileContext { get; init; }

        /// <summary>
        /// The transaction details.
        /// </summary>
        public Details Details { get; init; }

        /// <summary>
        /// The envelope associated with the transaction.
        /// </summary>
        public TEnvelope? Envelope { get; init; }

        /// <summary>
        /// A model describing the merchant participating in the transaction.
        /// </summary>
        public Merchant Merchant { get; init; }

        /// <summary>
        /// The merchant's processor settings and attributes.
        /// </summary>
        public TAttributes ProcessorAttributes { get; init; }

        /// <summary>
        /// The reader context derived from the transaction.
        /// </summary>
        public ReaderContext ReaderContext { get; init; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    }
}
