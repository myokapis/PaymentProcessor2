using System.Text.Json.Serialization;

namespace Payment.Processor.Transaction.Context
{
    public class Card
    {
        public Card()
        { }

        public string? Address { get; set; }
        public required string Brand { get; set; }

        [JsonPropertyName("cvv")]
        public string? CVV { get; set; }

        [JsonPropertyName("data_source")]
        public required string DataSource { get; set; }

        [JsonPropertyName("expiration_month")]
        public required string ExpirationMonth { get; set; }

        [JsonPropertyName("expiration_year")]
        public required string ExpirationYear { get; set; }

        public string? Name { get; set; }
        public string? Number { get; set; }

        [JsonPropertyName("service_code")]
        public string? ServiceCode { get; init; }

        [JsonPropertyName("tlv")]
        public string? TLV { get; set; }

        [JsonPropertyName("track1")]
        public string? Track1 { get; set; }

        [JsonPropertyName("track2")]
        public string? Track2 { get; set; }

        [JsonPropertyName("transaction_method")]
        public required string TransactionMethod { get; set; }

        [JsonPropertyName("zip_code")]
        public string? ZipCode { get; set; }
    }
}
