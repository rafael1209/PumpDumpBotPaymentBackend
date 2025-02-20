using Newtonsoft.Json;

namespace PumpDumpBotPaymentBackend.Models
{
    public class CryptocloudRequest
    {
        public string? status { get; set; }

        public string? invoice_id { get; set; }

        public decimal? amount_crypto { get; set; }

        public string? currency { get; set; }

        public string? order_id { get; set; }

        public string? token { get; set; }
    }
}
