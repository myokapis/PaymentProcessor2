using System.Text.Json.Serialization;

namespace Payment.Processor.Transaction.Model
{
    public class Reader
    {
        public bool EmvCapable { get; init; }
        public bool MsrCapable { get; init; }
        public bool NfcCapable { get; init; }

        [JsonPropertyName("serial_number")]
        public required string SerialNumber { get; init; }

        public required string Type { get; init; }
    }
}
