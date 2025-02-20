using MongoDB.Driver;
using PumpDumpBotPaymentBackend.Models;

namespace PumpDumpBotPaymentBackend.Interface;

public interface IMongoDbContext
{
    IMongoCollection<Payment> PaymentCollection { get; }
}