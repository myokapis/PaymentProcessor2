using Payment.Processor.Transaction.Model;

namespace Payment.Processor.Transaction.Context
{
    /// <summary>
    /// Describes a transaction context.
    /// </summary>
    /// <typeparam name="TEnvelope">The type of the envelope used in the transaction.</typeparam>
    /// <typeparam name="TAttributes">The type of the processor attributes used in the transaction.</typeparam>
    public interface ITransactionContext<TEnvelope, TAttributes>
        where TEnvelope : IEnvelope
        where TAttributes : IProcessorAttributes
    {
        /// <summary>
        /// The action context derived from the transaction.
        /// </summary>
        ActionContext ActionContext { get; set; }

        /// <summary>
        /// The card context derived from the transaction.
        /// </summary>
        CardContext CardContext { get; set; }

        /// <summary>
        /// The card on file context derived from the transaction.
        /// </summary>
        CardOnFileContext CardOnFileContext { get; set; }

        /// <summary>
        /// The transaction details.
        /// </summary>
        Details Details { get; set; }

        /// <summary>
        /// The envelope associated with the transaction.
        /// </summary>
        TEnvelope? Envelope { get; set; }

        /// <summary>
        /// A model describing the merchant participating in the transaction.
        /// </summary>
        Merchant Merchant { get; set; }

        /// <summary>
        /// The merchant's processor settings and attributes.
        /// </summary>
        TAttributes ProcessorAttributes { get; set; }

        /// <summary>
        /// The reader context derived from the transaction.
        /// </summary>
        ReaderContext ReaderContext { get; set; }
    }
}
