using Microsoft.AspNetCore.Identity;
using SubtitleRed.Shared;

namespace SubtitleRed.Infrastructure.Identity.JWT;

public interface IJwtGenerator
{
    Result<string, Error> CreateJwtToken(IdentityUser<Guid> user, IEnumerable<string> userRoles);
}