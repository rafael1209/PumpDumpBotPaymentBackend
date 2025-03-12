using MongoDB.Driver;
using PumpDumpBotPaymentBackend.Interface;

namespace PumpDumpBotPaymentBackend.Services
{
    public class TestService(IConfiguration configuration) : ITestService
    {
        public string Test()
        {
            return $"{DateTime.Now}";
        }
    }
}
