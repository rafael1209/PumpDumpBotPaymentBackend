using System.Text;
using MongoDB.Bson;
using PumpDumpBotPaymentBackend.Interface;
using PumpDumpBotPaymentBackend.Models;
using Newtonsoft.Json;
using PumpDumpBotPaymentBackend.Enums;

namespace PumpDumpBotPaymentBackend.Services;

public class PaymentService(
    IConfiguration configuration,
    IPaymentRepository paymentRepository,
    ITokenValidator tokenValidator) : IPaymentService
{
    private readonly HttpClient _httpClient = new();

    private readonly string _apiKey = configuration.GetValue<string>("Cryptocloud:ApiKey") ??
                                         throw new Exception("JCryptocloud:ApiKey not found");
    private readonly string _shopId = configuration.GetValue<string>("Cryptocloud:ShopId") ??
                                         throw new Exception("Cryptocloud:ShopId not found");

    private const string BaseUrl = "https://api.cryptocloud.plus";

    public async Task IncomingPayment(CryptocloudRequest request)
    {
        if (request.token != null && !tokenValidator.ValidateToken(request.token))
            throw new UnauthorizedAccessException("Invalid token");

        if (request.invoice_id == null || request.currency == null || request.status == null)
            throw new ArgumentException("Missing required fields in the request.");

        if (!ObjectId.TryParse(request.order_id, out var id))
            throw new ArgumentException($"Invalid order_id format: {request.order_id}");

        var payment = await paymentRepository.GetByIdAsync(id) ??
                      throw new ArgumentException($"Payment with order_id {request.order_id} not found.");

        await paymentRepository.UpdateStatusAsync(id, Status.Paid);
    }

    public async Task<InvoiceApiResponse?> CreateInvoiceAsync(InvoiceRequest request, ObjectId orderId)
    {
        var requestBody = new InvoiceApiRequest
        {
            ShopId = _shopId,
            Amount = request.Amount,
            Currency = request.Currency ?? "USD",
            OrderId = orderId.ToString(),
            Email = request.CustomerEmail
        };

        var jsonContent = JsonConvert.SerializeObject(requestBody);
        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Token {_apiKey}");

        var response = await _httpClient.PostAsync($"{BaseUrl}/v2/invoice/create", content);

        if (!response.IsSuccessStatusCode)
            throw new Exception("Error Cryptocloud response is not successful");

        var responseContent = await response.Content.ReadAsStringAsync();
        var invoiceApiResponse = JsonConvert.DeserializeObject<InvoiceApiResponse>(responseContent);

        return invoiceApiResponse ?? throw new Exception("Error Cryptocloud create invoice request");
    }

    public async Task SaveNewInvoiceAsync(ObjectId orderId, ObjectId productId, ObjectId userId,
        InvoiceApiResponse? newPayment)
    {
        if (newPayment?.Result == null)
            throw new ArgumentNullException(nameof(newPayment), "Payment response is null.");

        if (!Uri.TryCreate(newPayment.Result.Link, UriKind.Absolute, out var paymentLink))
            throw new UriFormatException($"Invalid payment link: {newPayment.Result.Link}");

        var payment = new Payment(orderId: orderId, productId: productId.ToString(), amount: newPayment.Result.Amount,
            userId: userId.ToString(), paymentUrl: paymentLink.ToString(), status: newPayment.Result.Status);

        await paymentRepository.CreateAsync(payment);
    }
}