using System.Text.Json.Serialization;
using Payment.Processor.Transaction.Context;

namespace Payment.Processor.Transaction.Model
{
    /// <summary>
    /// Describes a credit card payment transaction.
    /// </summary>
    /// <typeparam name="TAttributes"></typeparam>
    public class TransactionModel<TEnvelope, TAttributes> : ITransactionModel, ITransactionModel<TEnvelope, TAttributes>
        where TEnvelope : IEnvelope
        where TAttributes : IProcessorAttributes
    {
        /// <summary>
        /// An object containing the details of the transaction.
        /// </summary>
        [JsonPropertyName("transaction_details")]
        public required Details Details { get; init; }

        /// <summary>
        /// An object containing details about a prior related transaction.
        /// </summary>
        public TEnvelope? Envelope { get; init; }

        /// <summary>
        /// An object representing the merchant associated with the transaction.
        /// </summary>
        public required Merchant Merchant { get; init; }

        /// <summary>
        /// The processor-specific values associated with the merchant.
        /// </summary>
        [JsonPropertyName("merchant_account_specific")]
        public required TAttributes ProcessorAttributes { get; init; }

        IProcessorAttributes ITransactionModel.ProcessorAttributes
        {
            get => ProcessorAttributes;
            init => ProcessorAttributes = (TAttributes)value;
        }
    }
}
