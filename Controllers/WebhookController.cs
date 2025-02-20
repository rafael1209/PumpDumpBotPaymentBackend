using Microsoft.AspNetCore.Mvc;
using PumpDumpBotPaymentBackend.Interface;
using PumpDumpBotPaymentBackend.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;

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
            try
            {
                await paymentService.IncomingPayment(request);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
