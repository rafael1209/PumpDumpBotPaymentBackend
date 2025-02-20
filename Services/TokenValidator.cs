using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PumpDumpBotPaymentBackend.Interface;

namespace PumpDumpBotPaymentBackend.Services
{
    public class TokenValidator(IConfiguration configuration) : ITokenValidator
    {
        private readonly string _secretKey = configuration.GetValue<string>("Jwt:SecretKey") ??
                                             throw new Exception("JwtSettings:SecretKey not found");

        public bool ValidateToken(string token)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
                var validationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = key,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };

                var principal = handler.ValidateToken(token, validationParameters, out _);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}