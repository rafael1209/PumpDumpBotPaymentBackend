using PumpDumpBotPaymentBackend.Enums;
using PumpDumpBotPaymentBackend.Interface;
using PumpDumpBotPaymentBackend.Models;

namespace PumpDumpBotPaymentBackend.Services;

public class PaymentService(IPaymentRepository paymentRepository, ITokenValidator tokenValidator) : IPaymentService
{
    public async Task CreatePaymentAsync(Payment paymentDetails)
    {
        await paymentRepository.CreateAsync(paymentDetails);
    }

    public async Task IncomingPayment(CryptocloudRequest request)
    {
        if (request.token != null && !tokenValidator.ValidateToken(request.token))
            return;

        if (request.invoice_id == null || request.currency == null || request.status == null)
            return;

        await paymentRepository.CreateAsync(new Payment(request.invoice_id, request.currency, request.status));
    }
}