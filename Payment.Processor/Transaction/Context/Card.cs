using System.Text.Json.Serialization;

namespace Payment.Processor.Transaction.Context
{
    /// <summary>
    /// A model for the decrypted card data.
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Creates an instance of the card model.
        /// </summary>
        public Card()
        { }

        /// <summary>
        /// The address associated with the card.
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// The card brand name.
        /// </summary>
        public required string Brand { get; set; }

        /// <summary>
        /// The verification code from the card.
        /// </summary>
        [JsonPropertyName("cvv")]
        public string? CVV { get; set; }

        /// <summary>
        /// The data source that provided the card.
        /// </summary>
        [JsonPropertyName("data_source")]
        public required string DataSource { get; set; }

        /// <summary>
        /// The expiration month of the card.
        /// </summary>
        [JsonPropertyName("expiration_month")]
        public required string ExpirationMonth { get; set; }

        /// <summary>
        /// The expiration year of the card.
        /// </summary>
        [JsonPropertyName("expiration_year")]
        public required string ExpirationYear { get; set; }

        /// <summary>
        /// The name associated with the card.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The card number.
        /// </summary>
        public string? Number { get; set; }

        /// <summary>
        /// The service code from the card.
        /// </summary>
        [JsonPropertyName("service_code")]
        public string? ServiceCode { get; init; }

        /// <summary>
        /// The TLV data generated from the card and the transaction.
        /// </summary>
        [JsonPropertyName("tlv")]
        public string? TLV { get; set; }

        /// <summary>
        /// The track one data read from the card's magnetic stripe.
        /// </summary>
        [JsonPropertyName("track1")]
        public string? Track1 { get; set; }

        /// <summary>
        /// The track two data read from the card's magnetic stripe.
        /// </summary>
        [JsonPropertyName("track2")]
        public string? Track2 { get; set; }

        /// <summary>
        /// The transaction method used to acquire the card data.
        /// </summary>
        [JsonPropertyName("transaction_method")]
        public required string TransactionMethod { get; set; }

        /// <summary>
        /// The zip code associated with the card.
        /// </summary>
        [JsonPropertyName("zip_code")]
        public string? ZipCode { get; set; }
    }
}
