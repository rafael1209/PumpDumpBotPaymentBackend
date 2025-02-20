using MongoDB.Bson;
using PumpDumpBotPaymentBackend.Models;

namespace PumpDumpBotPaymentBackend.Interface;

public interface IPaymentRepository
{
    Task CreateAsync(Payment payment);
    Task UpdateAsync(ObjectId paymentId,Payment newPayment);
    Task<Payment> GetByIdAsync(ObjectId paymentId);
}