using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Payment.Processor.Transaction.Model
{
    // TODO: add validations particularly on the token

    /// <summary>
    /// 
    /// </summary>
    public class Details
    {
        /// <summary>
        /// A string representation of the requested transaction action.
        /// </summary>
        [RegularExpression(@"^(AUTH|AUTO_VOID|BALANCE_INQUIRY|CAPTURE|CARD_AUTHENTICATION|PARTIAL_REVERSAL|PRE_AUTH|RETURN|SALE|TIMEOUT_REVERSAL|VOID)$")]
        public required string Action { get; init; }

        /// <summary>
        /// The token from a prior transaction that is associated with the current request.
        /// </summary>
        public string? AssociatedId { get; init; }

        /// <summary>
        /// The amount of the beverage portion of the transaction.
        /// </summary>
        public int? BeverageAmount { get; init; }

        /// <summary>
        /// An encrypted string that represents a card object.
        /// </summary>
        [Required]
        [JsonPropertyName("encrypted_card_data")]
        public string? EncryptedCardData { get; init; }

        // TODO: see what this is and if/how we should use it
        /// <summary>
        /// Unknown
        /// </summary>
        public string? CardOnFile { get; init; }

        /// <summary>
        /// Ignore this value.
        /// </summary>
        public bool? CardPresent { get; init; }

        /// <summary>
        /// Ignore this value.
        /// </summary>
        public bool? CardholderPresent { get; init; }

        // TODO: see if this should be a string
        /// <summary>
        /// A description of the transaction.
        /// </summary>
        public object? CardholderTransactionReference { get; init; }

        // TODO: see if this should be boolean and if we should even us it
        public object? Ecommerce { get; init; }

        /// <summary>
        /// A flag that indicates if the reader was forced to fall back to another
        /// transaction method because the preferred transaction method was unsuccessful.
        /// </summary>
        public bool? Fallback { get; init; }

        /// <summary>
        /// The amount of the food portion of the transaction.
        /// </summary>
        public int? FoodAmount { get; init; }

        /// <summary>
        /// The token from the current transaction.
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Additional transaction data.
        /// </summary>
        public Metadata? Metadata { get; init; }

        // TODO: see if this should be boolean and if we should even use it
        public object? Moto { get; init; }

        /// <summary>
        /// The token from the original transaction associated with the current transaction.
        /// </summary>
        public string? OriginalId { get; init; }

        // TODO: see what this is an if we should even use it
        public object? ProcessorOptions { get; init; }

        /// <summary>
        /// Ignore this value.
        /// </summary>
        public string? ProductContext { get; set; }

        /// <summary>
        /// An object representing the reader used to make the transaction.
        /// </summary>
        [Required]
        public Reader? Reader { get; set; }

        // TODO: see what this is an if we should even use it
        public object? StoreAndForward { get; init; }

        // TODO: see what this is an if we should even use it
        public object? StoreCard { get; init; }

        /// <summary>
        /// The amount of the surcharge portion of the transaction.
        /// </summary>
        public object? SurchargeAmount { get; init; }

        /// <summary>
        /// The amount of the tax portion of the transaction.
        /// </summary>
        public int? TaxAmount { get; set; }

        public object? TaxStatus { get; init; }
        public Dictionary<string, object>? TestPayload { get; init; }

        /// <summary>
        /// The amount of the tip portion of the transaction.
        /// </summary>
        public int? TipAmount { get; set; }

        // TODO: structure this as an object or array of objects
        public object? TransactionLevelData { get; init; }

        /// <summary>
        /// The total transaction amount.
        /// </summary>
        public int TotalAmount { get; init; }

        // TODO: see what this is and if we ever use it
        public string? VoidReason { get; init; }
    }
}
