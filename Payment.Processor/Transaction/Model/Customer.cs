using System.Text.Json.Serialization;

namespace Payment.Processor.Transaction.Model
{
    /// <summary>
    /// Models a customer object from the transaction metadata
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// A variant of the save card flag. The JSON key is 'save_card'.
        /// </summary>
        [JsonPropertyName("save_card")]
        public bool SaveCardAlt1 { protected get; set; } = false;

        /// <summary>
        /// A variant of the save card flag. The JSON key is 'saveCard'.
        /// </summary>
        [JsonPropertyName("saveCard")]
        public bool SaveCardAlt2 { protected get; set; } = false;

        /// <summary>
        /// A convenience method that provides a single source of truth for the save card flag.
        /// </summary>
        [JsonIgnore]
        public bool SaveCard => SaveCardAlt1 || SaveCardAlt2;
    }
}
