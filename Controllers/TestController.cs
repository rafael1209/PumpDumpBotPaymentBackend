using Microsoft.AspNetCore.Mvc;
using PumpDumpBotPaymentBackend.Interface;

namespace PumpDumpBotPaymentBackend.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestController(ITestService testService) : Controller
    {
        [HttpGet]
        public IActionResult Test()
        {
            return Json(testService.Test());
        }
    }
}
