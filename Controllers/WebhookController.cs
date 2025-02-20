using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using PumpDumpBotPaymentBackend.Interface;
using PumpDumpBotPaymentBackend.Models;

namespace PumpDumpBotPaymentBackend.Controllers
{
    [ApiController]
    [Route("api/webhook")]
    public class WebhookController(IPaymentService paymentService) : ControllerBase
    {
        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<IActionResult> Post([FromForm] CryptocloudRequest request)
        {
            await paymentService.

            return Ok();
        }
    }
}
