using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace SubtitleRed.Infrastructure.Identity.JWT;

internal class JwtTokenValidatorService : ISecurityTokenValidator
{
    private readonly IConfiguration _configuration;

    public bool CanValidateToken => true;

    public int MaximumTokenSizeInBytes { get; set; } = int.MaxValue;

    public JwtTokenValidatorService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public bool CanReadToken(string securityToken) => true;

    public ClaimsPrincipal ValidateToken(string securityToken, TokenValidationParameters validationParameters,
        out SecurityToken validatedToken)
    {
        var handler = new JwtSecurityTokenHandler();
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration[JwtGenerator.JwtTokenConfigurationPath]))
        };

        var claimsPrincipal = handler.ValidateToken(securityToken, tokenValidationParameters, out validatedToken);
        return claimsPrincipal;
    }
}