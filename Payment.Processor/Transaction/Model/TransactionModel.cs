using System.Text.Json.Serialization;

namespace Payment.Processor.Transaction.Model
{
    public class TransactionModel<TAttributes> : ITransactionModel, ITransactionModel<TAttributes>
        where TAttributes : IProcessorAttributes
    {
        [JsonPropertyName("transaction_details")]
        public required Details Details { get; init; }

        public required Merchant Merchant { get; init; }

        [JsonPropertyName("merchant_account_specific")]
        public required TAttributes ProcessorAttributes { get; init; }
        IProcessorAttributes ITransactionModel.ProcessorAttributes
        {
            get => ProcessorAttributes;
            init => ProcessorAttributes = (TAttributes)value;
        }
    }
}
