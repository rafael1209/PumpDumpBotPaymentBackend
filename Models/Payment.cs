using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using PumpDumpBotPaymentBackend.Enums;

namespace PumpDumpBotPaymentBackend.Models
{
    public class Payment(
        ObjectId orderId,
        string userId,
        string productId,
        decimal amount,
        string paymentUrl,
        string status)
    {
        [BsonId]
        public ObjectId Id { get; set; } = orderId;

        [BsonElement("userId")]
        public string UserId { get; set; } = userId;

        [BsonElement("productId")]
        public string ProductId { get; set; } = productId;

        [BsonElement("amount")]
        public decimal Amount { get; set; } = amount;

        [BsonElement("paymentUrl")]
        public Uri PaymentUrl { get; set; } = new(paymentUrl);

        [BsonElement("status")]
        [BsonRepresentation(BsonType.String)]
        public Status Status { get; set; } = Enum.TryParse<Status>(status, true, out var parsedStatus)
            ? parsedStatus
            : throw new ArgumentException($"Invalid status value: {status}");

        [BsonElement("createdAtUtc")]
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    }
}
