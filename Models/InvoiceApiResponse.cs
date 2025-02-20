using Newtonsoft.Json;

namespace PumpDumpBotPaymentBackend.Models
{
    public class InvoiceApiResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;

        [JsonProperty("result")]
        public InvoiceResult Result { get; set; } = new();
    }

    public class InvoiceResult
    {
        [JsonProperty("uuid")]
        public string Uuid { get; set; } = string.Empty;

        [JsonProperty("created")]
        public string Created { get; set; } = string.Empty;

        [JsonProperty("address")]
        public string Address { get; set; } = string.Empty;

        [JsonProperty("expiry_date")]
        public string ExpiryDate { get; set; } = string.Empty;

        [JsonProperty("side_commission")]
        public string SideCommission { get; set; } = string.Empty;

        [JsonProperty("side_commission_cc")]
        public string SideCommissionCc { get; set; } = string.Empty;

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("amount_usd")]
        public decimal AmountUsd { get; set; }

        [JsonProperty("amount_in_fiat")]
        public decimal AmountInFiat { get; set; }

        [JsonProperty("fee")]
        public decimal Fee { get; set; }

        [JsonProperty("fee_usd")]
        public decimal FeeUsd { get; set; }

        [JsonProperty("service_fee")]
        public decimal ServiceFee { get; set; }

        [JsonProperty("service_fee_usd")]
        public decimal ServiceFeeUsd { get; set; }

        [JsonProperty("type_payments")]
        public string TypePayments { get; set; } = string.Empty;

        [JsonProperty("fiat_currency")]
        public string FiatCurrency { get; set; } = string.Empty;

        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;

        [JsonProperty("is_email_required")]
        public bool IsEmailRequired { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; } = string.Empty;

        [JsonProperty("invoice_id")]
        public string? InvoiceId { get; set; }

        [JsonProperty("currency")]
        public CurrencyInfo Currency { get; set; } = new();

        [JsonProperty("project")]
        public ProjectInfo Project { get; set; } = new();

        [JsonProperty("test_mode")]
        public bool TestMode { get; set; }
    }

    public class CurrencyInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; } = string.Empty;

        [JsonProperty("fullcode")]
        public string FullCode { get; set; } = string.Empty;

        [JsonProperty("network")]
        public NetworkInfo Network { get; set; } = new();

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("is_email_required")]
        public bool IsEmailRequired { get; set; }

        [JsonProperty("stablecoin")]
        public bool Stablecoin { get; set; }

        [JsonProperty("icon_base")]
        public string IconBase { get; set; } = string.Empty;

        [JsonProperty("icon_network")]
        public string IconNetwork { get; set; } = string.Empty;

        [JsonProperty("icon_qr")]
        public string IconQr { get; set; } = string.Empty;

        [JsonProperty("order")]
        public int Order { get; set; }
    }

    public class NetworkInfo
    {
        [JsonProperty("code")]
        public string Code { get; set; } = string.Empty;

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; } = string.Empty;

        [JsonProperty("fullname")]
        public string FullName { get; set; } = string.Empty;
    }

    public class ProjectInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("fail")]
        public string FailUrl { get; set; } = string.Empty;

        [JsonProperty("success")]
        public string SuccessUrl { get; set; } = string.Empty;

        [JsonProperty("logo")]
        public string Logo { get; set; } = string.Empty;
    }
}
