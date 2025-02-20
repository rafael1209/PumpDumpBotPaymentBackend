using PumpDumpBotPaymentBackend.Models;

namespace PumpDumpBotPaymentBackend.Interface;

public interface IPaymentRepository
{
    Task CreateAsync(Payment payment);
}