using MongoDB.Bson;
using PumpDumpBotPaymentBackend.Models;

namespace PumpDumpBotPaymentBackend.Interface;

public interface IPaymentService
{
    Task IncomingPayment(CryptocloudRequest request);
    Task SaveNewInvoiceAsync(ObjectId orderId, ObjectId productId, ObjectId userId,
        InvoiceApiResponse? newPayment);
    Task<InvoiceApiResponse?> CreateInvoiceAsync(InvoiceRequest request, ObjectId orderId);
}