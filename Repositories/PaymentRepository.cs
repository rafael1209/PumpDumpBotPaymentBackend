using MongoDB.Bson;
using MongoDB.Driver;
using PumpDumpBotPaymentBackend.Database;
using PumpDumpBotPaymentBackend.Enums;
using PumpDumpBotPaymentBackend.Interface;
using PumpDumpBotPaymentBackend.Models;

namespace PumpDumpBotPaymentBackend.Repositories
{
    public class PaymentRepository(MongoDbContext context) : IPaymentRepository
    {
        private readonly IMongoCollection<Payment> _paymentCollection = context.PaymentCollection;

        public async Task CreateAsync(Payment paymentDetails)
        {
            await _paymentCollection.InsertOneAsync(paymentDetails);
        }

        public async Task UpdateStatusAsync(ObjectId paymentId, Status status)
        {
            var filter = Builders<Payment>.Filter.Eq(p => p.Id, paymentId);
            var update = Builders<Payment>.Update
                .Set(p => p.Status, status);

            await _paymentCollection.UpdateOneAsync(filter, update);
        }

        public async Task<Payment> GetByIdAsync(ObjectId paymentId)
        {
            return await _paymentCollection.Find(payment => payment.Id == paymentId).FirstOrDefaultAsync();
        }
    }
}