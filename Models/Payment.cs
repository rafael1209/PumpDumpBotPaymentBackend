using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using PumpDumpBotPaymentBackend.Enums;

namespace PumpDumpBotPaymentBackend.Models
{
    public class Payment(string invoiceId, string currency, string status)
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("invoice-id")]
        public string InvoiceId { get; set; } = invoiceId;

        [BsonElement("currency")]
        public string Currency { get; set; } = currency;

        [BsonElement("status")]
        [BsonRepresentation(BsonType.String)]
        public Status Status { get; set; } = Enum.TryParse(status, out Status s)
            ? s
            : throw new ArgumentException($"Invalid status: {status}");

        [BsonElement("created-at-utc")]
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    }
}
