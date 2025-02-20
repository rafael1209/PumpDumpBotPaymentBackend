using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using PumpDumpBotPaymentBackend.Enums;

namespace PumpDumpBotPaymentBackend.Models
{
    public class Payment(ObjectId orderId, string userId, decimal amount, Uri paymentUri, string currency, string status)
    {
        [BsonId]
        public ObjectId Id { get; set; } = orderId;

        [BsonElement("userId")]
        public string UserId { get; set; } = userId;

        [BsonElement("amount")]
        public decimal Amount { get; set; } = amount;

        [BsonElement("currency")]
        public string Currency { get; set; } = currency;

        [BsonElement("payment-url")]
        public Uri PaymentUrl { get; set; } = paymentUri;

        [BsonElement("status")]
        [BsonRepresentation(BsonType.String)]
        public Status Status { get; set; } = Enum.TryParse<Status>(status, true, out var parsedStatus)
            ? parsedStatus
            : throw new ArgumentException($"Invalid status value: {status}");

        [BsonElement("created-at-utc")]
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    }
}
