using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using PumpDumpBotPaymentBackend.Interface;
using PumpDumpBotPaymentBackend.Models;

namespace PumpDumpBotPaymentBackend.Controllers
{
    [ApiController]
    [Route("api/invoice")]
    public class InvoiceController(IPaymentService paymentService) : Controller
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] InvoiceRequest request)
        {
            if (!ObjectId.TryParse(request.UserId, out var id))
                return BadRequest("Invalid userId");

            var orderId = ObjectId.GenerateNewId();

            var response =  await paymentService.CreateInvoiceAsync(request, orderId);

            await paymentService.SaveNewInvoiceAsync(orderId, request.UserId, response);

            return Json(response);
        }
    }
}
