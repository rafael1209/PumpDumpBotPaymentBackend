using MongoDB.Bson;
using PumpDumpBotPaymentBackend.Models;

namespace PumpDumpBotPaymentBackend.Interface;

public interface IPaymentService
{
    Task IncomingPayment(CryptocloudRequest request);
    Task<InvoiceApiResponse?> CreateInvoiceAsync(InvoiceRequest request, ObjectId orderId);
    Task SaveNewInvoiceAsync(ObjectId orderId, string userId, InvoiceApiResponse? newResponse);
}