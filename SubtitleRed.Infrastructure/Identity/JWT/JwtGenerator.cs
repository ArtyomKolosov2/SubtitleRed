using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SubtitleRed.Shared;

namespace SubtitleRed.Infrastructure.Identity.JWT;

internal class JwtGenerator : IJwtGenerator
{
    internal const string JwtTokenConfigurationPath = "JwtTokenKey";
    private readonly SymmetricSecurityKey _key;

    public JwtGenerator(IConfiguration configuration)
    {
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration[JwtTokenConfigurationPath]));
    }

    public Result<string, Error> CreateJwtToken(IdentityUser<Guid> user, IEnumerable<string> userRoles)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Email, user.Email),
        };

        claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

        var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(1),
            SigningCredentials = credentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return Result<string, Error>.Success(tokenHandler.WriteToken(token));
    }
}