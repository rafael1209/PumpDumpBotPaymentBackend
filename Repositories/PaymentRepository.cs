using MongoDB.Bson;
using MongoDB.Driver;
using PumpDumpBotPaymentBackend.Database;
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

        public async Task UpdateAsync(ObjectId paymentId, Payment newPayment)
        {
            await _paymentCollection.ReplaceOneAsync(payment => payment.Id == paymentId, newPayment);
        }

        public async Task<Payment> GetByIdAsync(ObjectId paymentId)
        {
            return await _paymentCollection.Find(payment => payment.Id == paymentId).FirstOrDefaultAsync();
        }
    }
}