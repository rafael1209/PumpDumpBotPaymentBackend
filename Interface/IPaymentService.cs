using PumpDumpBotPaymentBackend.Models;

namespace PumpDumpBotPaymentBackend.Interface;

public interface IPaymentService
{
    Task CreatePaymentAsync(Payment paymentDetails);
    Task IncomingPayment(CryptocloudRequest request);
}