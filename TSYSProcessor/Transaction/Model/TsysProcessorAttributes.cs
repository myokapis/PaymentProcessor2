using System.Text.Json.Serialization;
using Payment.Processor.Transaction.Model.V1;

namespace TsysProcessor.Transaction.Model
{
    public class TsysProcessorAttributes : IProcessorAttributes
    {
        [JsonPropertyName("tsysd_bin")]
        public int AcquirerBin { get; set; }

        [JsonPropertyName("tsysd_agent_bank_number")]
        public required string AgentBankNumber { get; set; }

        [JsonPropertyName("tsysd_chain_number")]
        public required string AgentChainNumber { get; set; }

        public string? AuthenticationCode { get; set; }

        [JsonPropertyName("tsysd_zip_code")]
        public required string CityCode { get; set; }

        public string? GenKey { get; set; }

        [JsonPropertyName("tsysd_sic_code")]
        public int MerchantCategoryCode { get; set; }

        [JsonPropertyName("tsysd_location_number")]
        public required string MerchantLocationNumber { get; set; }

        [JsonPropertyName("tsysd_merchant_number")]
        public ulong MerchantNumber { get; set; }

        [JsonPropertyName("tsysd_store_number")]
        public int StoreNumber { get; set; }

        [JsonPropertyName("tsysd_terminal_id")]
        public required string TerminalIdNumber { get; set; }

        [JsonPropertyName("tsysd_terminal_number")]
        public int TerminalNumber { get; set; }
    }
}
