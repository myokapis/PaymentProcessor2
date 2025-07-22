using System.Text.Json.Serialization;

namespace Payment.Processor.Transaction.Model
{
    public class Metadata
    {
        public bool CardAuthentication { get; set; } = false;
        public Customer? Customer { get; set; }

        [JsonPropertyName("ip_address")]
        public string? IPAddress { get; set; }

        public Item[]? Items { get; set; }
        public PaymentPlan? PaymentPlan { get; set; }
        public string? Platform { get; set; }

        [JsonPropertyName("time_zone")]
        public string? TimeZone { get; set; }

        [JsonPropertyName("user_agent")]
        public string? UserAgent { get; set; }

        public string? UserEmail { get; set; }
    }
}
