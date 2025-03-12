namespace PumpDumpBotPaymentBackend.Models
{
    public class InvoiceRequest
    {
        public required decimal Amount { get; set; }
        public required string UserId { get; set; }
        public required string ProductId { get; set; }
        public string? Currency { get; set; }
        public string? CustomerEmail { get; set; }
    }
}
