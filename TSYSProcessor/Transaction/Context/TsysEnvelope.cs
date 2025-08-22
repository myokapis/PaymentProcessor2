using System.Text.Json.Serialization;
using Payment.Processor.Transaction.Context.V1;

namespace TsysProcessor.Transaction.Context
{
    public class TsysEnvelope : IEnvelope
    {
        [JsonPropertyName("associated_id")]
        public string? AssociatedId { get; set; }

        [JsonPropertyName("authorization_code")]
        public string? AuthorizationCode { get; set; }

        [JsonPropertyName("class")]
        public string? Class { get; set; }

        /// <summary>
        /// This property indicates that the envelope is a default, empty envelope.
        /// </summary>
        [JsonIgnore()]
        public bool Empty { get; set; } = false;

        [JsonPropertyName("local_transaction_date")]
        public string? LocalTransactionDate { get; set; }

        [JsonPropertyName("local_transaction_time")]
        public string? LocalTransactionTime { get; set; }

        [JsonPropertyName("raw_message")]
        public string? RawMessage { get; set; }

        [JsonPropertyName("response_text")]
        public string? ResponseText { get; set; }

        [JsonPropertyName("retrieval_reference_number")]
        public string? RetrievalReferenceNumber { get; set; }

        [JsonPropertyName("returned_aci")]
        public string? ReturnedAci { get; set; }

        [JsonPropertyName("transaction_id")]
        public string? TransactionId { get; set; }

        [JsonPropertyName("transaction_link_identifier")]
        public string? TransactionLinkIdentifier { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; } = "0.1";

    }
}
