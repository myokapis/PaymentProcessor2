using Payment.Processor.Enums;

namespace Payment.Processor.Transaction.Result
{
    // TODO: finish this and also make sure the enum serializes correctly

    /// <summary>
    /// Describes the transaction result message that is enqueued for Gateway.
    /// </summary>
    public class ResultMessage
    {
        /// <summary>
        /// The modified transaction amount.
        /// </summary>
        /// <remarks>When a transaction is partially approved, the partially approved amount
        /// is returned to Gateway.</remarks>
        public int? Amount { get; init; }

        /// <summary>
        /// The authorization code returned by the processor if the transaction was approved.
        /// </summary>
        public string? AuthCode { get; init; }

        /// <summary>
        /// An object representing the results of the processor's address and zip code matching.
        /// </summary>
        public object? AvsResults { get; init; }

        /// <summary>
        /// The token uniquely identifying the transaction.
        /// </summary>
        public required string Id { get; init; }

        /// <summary>
        /// A message describing the transaction result or providing additional information.
        /// </summary>
        public string? Message { get; init; }

        /// <summary>
        /// TLV data returned by the processor in their response to the transaction request.
        /// </summary>
        public string? ResponseTLV { get; init; }

        /// <summary>
        /// An enumerated value representing the result of the transaction.
        /// </summary>
        public required TransactionResult Result { get; init; }

        /// <summary>
        /// The result message version.
        /// </summary>
        public string Version { get; init; } = "1.0.0";
    }
}
