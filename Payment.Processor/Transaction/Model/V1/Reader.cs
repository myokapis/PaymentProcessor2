using System.Text.Json.Serialization;

namespace Payment.Processor.Transaction.Model.V1
{
    public class Reader
    {
        /// <summary>
        /// Flag that indicates if EMV contact capabilities were enabled on the reader.
        /// </summary>
        [JsonPropertyName("emv_capable")]
        public bool EmvEnabled { get; init; }

        /// <summary>
        /// Flag that indicates if magnetic stripe reading capabilities were enabled on the reader.
        /// </summary>
        [JsonPropertyName("msr_capable")]
        public bool MsrEnabled { get; init; }

        /// <summary>
        /// Flag that indicates if EMV contactless capabilities were enabled on the reader.
        /// </summary>
        [JsonPropertyName("nfc_capable")]
        public bool NfcEnabled { get; init; }

        /// <summary>
        /// The reader's serial number.
        /// </summary>
        [JsonPropertyName("serial_number")]
        public required string SerialNumber { get; init; }

        /// <summary>
        /// The reader's model.
        /// </summary>
        public required string Type { get; init; }
    }
}
