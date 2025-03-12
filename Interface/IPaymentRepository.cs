using MongoDB.Bson;
using PumpDumpBotPaymentBackend.Enums;
using PumpDumpBotPaymentBackend.Models;

namespace PumpDumpBotPaymentBackend.Interface;

public interface IPaymentRepository
{
    Task CreateAsync(Payment payment);
    Task UpdateStatusAsync(ObjectId paymentId, Status status);
    Task<Payment> GetByIdAsync(ObjectId paymentId);
}