using System.Security.Claims;

namespace PumpDumpBotPaymentBackend.Interface;

public interface ITokenValidator
{
    bool ValidateToken(string token);
}