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
        public string? Address { get; init; }

        /// <summary>
        /// The card brand name.
        /// </summary>
        public required string Brand { get; init; }

        /// <summary>
        /// The verification code from the card.
        /// </summary>
        [JsonPropertyName("cvv")]
        public string? CVV { get; init; }

        /// <summary>
        /// The data source that provided the card.
        /// </summary>
        [JsonPropertyName("data_source")]
        public required string DataSource { get; init; }

        /// <summary>
        /// The expiration month of the card.
        /// </summary>
        [JsonPropertyName("expiration_month")]
        public required string ExpirationMonth { get; init; }

        /// <summary>
        /// The expiration year of the card.
        /// </summary>
        [JsonPropertyName("expiration_year")]
        public required string ExpirationYear { get; init; }

        /// <summary>
        /// The name associated with the card.
        /// </summary>
        public string? Name { get; init; }

        /// <summary>
        /// The card number.
        /// </summary>
        public string? Number { get; init; }

        /// <summary>
        /// The service code from the card.
        /// </summary>
        [JsonPropertyName("service_code")]
        public string? ServiceCode { get; init; }

        /// <summary>
        /// The TLV data generated from the card and the transaction.
        /// </summary>
        [JsonPropertyName("tlv")]
        public string? TLV { get; init; }

        /// <summary>
        /// The track one data read from the card's magnetic stripe.
        /// </summary>
        [JsonPropertyName("track1")]
        public string? Track1 { get; init; }

        /// <summary>
        /// The track two data read from the card's magnetic stripe.
        /// </summary>
        [JsonPropertyName("track2")]
        public string? Track2 { get; init; }

        /// <summary>
        /// The transaction method used to acquire the card data.
        /// </summary>
        [JsonPropertyName("transaction_method")]
        public required string TransactionMethod { get; init; }

        /// <summary>
        /// The zip code associated with the card.
        /// </summary>
        [JsonPropertyName("zip_code")]
        public string? ZipCode { get; init; }
    }
}
