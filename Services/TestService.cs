using MongoDB.Driver;
using PumpDumpBotPaymentBackend.Interface;

namespace PumpDumpBotPaymentBackend.Services
{
    public class TestService(IConfiguration configuration) : ITestService
    {
        public string Test()
        {
            string _apiKey = configuration.GetValue<string>("Cryptocloud:ApiKey") ??
                                              throw new Exception("JCryptocloud:ApiKey not found");
            string _shopId = configuration.GetValue<string>("Cryptocloud:ShopId") ??
                                              throw new Exception("Cryptocloud:ShopId not found");
            string _secretKey = configuration.GetValue<string>("Cryptocloud:SecretJwtKey") ??
                                throw new Exception("JwtSettings:SecretKey not found");
            string client = configuration.GetValue<string>("MongoDb:ConnectionString");
            string client1 = configuration.GetValue<string>("MongoDb:Name");

            return _apiKey + "KEY\n" + _shopId + "SHOP_ID\n" + _secretKey + "SECRETE\n" + client + "CLIENT\n" +
                   client1 + "CLIENT1\n";
        }
    }
}
