using System.Text.Json.Serialization;

namespace Payment.Processor.Transaction.Model
{
    public class Customer
    {
        [JsonPropertyName("save_card")]
        public bool SaveCardAlt1 { protected get; set; } = false;

        [JsonPropertyName("saveCard")]
        public bool SaveCardAlt2 { protected get; set; } = false;

        [JsonIgnore]
        public bool SaveCard => SaveCardAlt1 || SaveCardAlt2;
    }
}
