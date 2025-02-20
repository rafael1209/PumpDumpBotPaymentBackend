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
    }
}