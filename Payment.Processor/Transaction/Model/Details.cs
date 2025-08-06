using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Payment.Processor.Transaction.Model
{
    // TODO: add validations particularly on the token
    public class Details
    {
        [RegularExpression(@"^(AUTH|AUTO_VOID|BALANCE_INQUIRY|CAPTURE|CARD_AUTHENTICATION|PARTIAL_REVERSAL|PRE_AUTH|RETURN|SALE|TIMEOUT_REVERSAL|VOID)$")]
        public required string Action { get; init; }

        public string? AssociatedId { get; init; }
        public int? BeverageAmount { get; init; }

        [JsonPropertyName("encrypted_card_data")]
        public required string EncryptedCardData { get; init; }

        public string? CardOnFile { get; init; }
        public bool? CardPresent { get; init; }
        public bool? CardholderPresent { get; init; }
        public object? CardholderTransactionReference { get; init; }
        public object? Ecommerce { get; init; }
        public bool? Fallback { get; init; }
        public int? FoodAmount { get; init; }
        public string? Id { get; set; }
        public Metadata? Metadata { get; init; }
        public object? Moto { get; init; }
        public string? OriginalId { get; init; }
        public object? ProcessorOptions { get; init; }
        public string? ProductContext { get; set; }
        public required Reader Reader { get; set; }
        public object? StoreAndForward { get; init; }
        public object? StoreCard { get; init; }
        public object? SurchargeAmount { get; init; }
        public int? TaxAmount { get; set; }
        public object? TaxStatus { get; init; }
        public Dictionary<string, object>? TestPayload { get; init; }
        public int? TipAmount { get; set; }

        // TODO: structure this as an object or array of objects
        public object? TransactionLevelData { get; init; }
        public int TotalAmount { get; init; }
        public string? VoidReason { get; init; }
    }
}
