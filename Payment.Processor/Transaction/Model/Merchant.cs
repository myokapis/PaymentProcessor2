using System.Text.Json.Serialization;

namespace Payment.Processor.Transaction.Model
{
    // TODO: see which of these properties are actually needed and remove the others
    //       Also not all of the currently required are actually required.
    //       Remove required and set a default for fields we don't care about.
    public class Merchant
    {
        [JsonPropertyName("account_token")]
        public required string AccountToken { get; init; }

        //public int ApiKeyId { get; init; }

        [JsonPropertyName("as_merchant_account_id")]
        public int AsMerchantAccountId { get; init; }

        [JsonPropertyName("as_merchant_account_type")]
        public required string AsMerchantAccountType { get; init; }

        [JsonPropertyName("string_batch_time")]
        public required string BatchTime { get; init; }

        [JsonPropertyName("debit_allowed")]
        public bool DebitAllowed { get; init; }

        public required string Industry { get; init; }

        [JsonPropertyName("keyed_allowed")]
        public bool KeyedAllowed { get; init; }

        [JsonPropertyName("keyed_rate")]
        public required string KeyedRate { get; init; }

        public required string Name { get; init; }
        public required string State { get; init; }
        public required string Status { get; init; }

        [JsonPropertyName("time_zone")]
        public required string TimeZone { get; init; }

        [JsonPropertyName("tipping_mode")]
        public string TippingMode { get; init; } = string.Empty;

        [JsonPropertyName("transaction_fee")]
        public int TransactionFee { get; init; }
    }
}
