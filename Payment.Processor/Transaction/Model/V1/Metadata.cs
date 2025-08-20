using System.Text.Json.Serialization;

namespace Payment.Processor.Transaction.Model.V1
{
    /// <summary>
    /// Additional transaction data.
    /// </summary>
    public class Metadata
    {
        /// <summary>
        /// Flag that indicates if the transaction is for card authentication only.
        /// </summary>
        public bool CardAuthentication { get; set; } = false;

        /// <summary>
        /// An object representing the customer associated with the transaction.
        /// </summary>
        public Customer? Customer { get; set; }

        /// <summary>
        /// The IP address from which the transaction originated.
        /// </summary>
        /// <remarks>This value may not be reliable.</remarks>
        [JsonPropertyName("ip_address")]
        public string? IPAddress { get; set; }

        /// <summary>
        /// The collection of items being purchased as part of the transaction.
        /// </summary>
        public Item[]? Items { get; set; }

        /// <summary>
        /// An object representing the payment plan associated with the transaction.
        /// </summary>
        public PaymentPlan? PaymentPlan { get; set; }

        /// <summary>
        /// The software platform on which the transaction was taken.
        /// </summary>
        public string? Platform { get; set; }

        // TODO: see what this is and if we use it.
        [JsonPropertyName("time_zone")]
        public string? TimeZone { get; set; }


        [JsonPropertyName("user_agent")]
        public string? UserAgent { get; set; }

        // TODO: see what this is and if we use it
        public string? UserEmail { get; set; }
    }
}
