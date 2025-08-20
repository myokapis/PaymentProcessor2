using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Payment.Processor.Transaction.Model.V1
{
    // TODO: see which of these properties are actually needed and remove the others
    //       Also not all of the currently required are actually required.
    //       Remove required and set a default for fields we don't care about.

    /// <summary>
    /// Describes the merchant account associated with the current transaction.
    /// </summary>
    public class Merchant
    {
        /// <summary>
        /// A token that uniquely identifies the account.
        /// </summary>
        [Required]
        [JsonPropertyName("account_token")]
        public string? AccountToken { get; init; }

        //public int ApiKeyId { get; init; }

        /// <summary>
        /// A database identifier that references processor-specific data for the merchant.
        /// </summary>
        [JsonPropertyName("as_merchant_account_id")]
        public int AsMerchantAccountId { get; init; }

        /// <summary>
        /// The processor to which the merchant's transactions are submitted.
        /// </summary>
        [JsonPropertyName("as_merchant_account_type")]
        public string? AsMerchantAccountType { get; init; }

        /// <summary>
        /// A string representation of the merchant's daily batch time.
        /// </summary>
        [JsonPropertyName("string_batch_time")]
        public string? BatchTime { get; init; }

        // TODO: see if we use this
        [JsonPropertyName("debit_allowed")]
        public bool DebitAllowed { get; init; }

        /// <summary>
        /// The merchant's assigned industry.
        /// </summary>
        [Required]
        public string? Industry { get; init; }

        /// <summary>
        /// A flag indicating if the merchant is allowed to accept keyed transactions.
        /// </summary>
        [JsonPropertyName("keyed_allowed")]
        public bool KeyedAllowed { get; init; }

        /// <summary>
        /// Indicates whether keyed transactions should be processed as MOTO or retail.
        /// </summary>
        [JsonPropertyName("keyed_rate")]
        public string? KeyedRate { get; init; }

        /// <summary>
        /// The merchant's name.
        /// </summary>
        [Required]
        public string? Name { get; init; }

        /// <summary>
        /// The merchant's state or territory.
        /// </summary>
        [Required]
        public string? State { get; init; }

        /// <summary>
        /// The merchant's account status.
        /// </summary>
        public string? Status { get; init; }

        /// <summary>
        /// The merchant's time zone.
        /// </summary>
        [JsonPropertyName("time_zone")]
        public string? TimeZone { get; init; }

        [JsonPropertyName("tipping_mode")]
        public string? TippingMode { get; init; }

        [JsonPropertyName("transaction_fee")]
        public int TransactionFee { get; init; }
    }
}
