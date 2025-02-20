using MongoDB.Driver;
using PumpDumpBotPaymentBackend.Interface;
using PumpDumpBotPaymentBackend.Models;

namespace PumpDumpBotPaymentBackend.Database
{
    public class MongoDbContext : IMongoDbContext
    {
        private readonly IMongoDatabase _database;

        private const string ConstPaymentsCollection = "payments";

        public MongoDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("MongoDb:ConnectionString"));
            _database = client.GetDatabase(configuration.GetValue<string>("MongoDb:Name"));
        }

        public IMongoCollection<Payment> PaymentCollection => _database.GetCollection<Payment>(ConstPaymentsCollection);
    }
}
