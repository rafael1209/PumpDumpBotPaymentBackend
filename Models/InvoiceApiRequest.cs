using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace PumpDumpBotPaymentBackend.Models
{
    public class InvoiceApiRequest
    {
        [JsonProperty("shop_id")]
        public required string ShopId { get; set; }
        [JsonProperty("amount")]
        public required decimal Amount { get; set; }
        [JsonProperty("currency")]
        public string? Currency { get; set; }
        [JsonProperty("order_id")]
        public string? OrderId { get; set; }
        [JsonProperty("email")]
        public string? Email { get; set; }
    }
}
