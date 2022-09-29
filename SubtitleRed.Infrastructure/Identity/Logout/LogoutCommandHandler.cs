using MediatR;
using Microsoft.AspNetCore.Identity;
using SubtitleRed.Shared;

namespace SubtitleRed.Infrastructure.Identity.Logout;

public class LogoutCommandHandler : IRequestHandler<LogoutCommand, Result<LogoutResponseDto, Error>>
{
    private readonly SignInManager<IdentityUser<Guid>> _signInManager;

    public LogoutCommandHandler(SignInManager<IdentityUser<Guid>> signInManager)
    {
        _signInManager = signInManager;
    }

    public async Task<Result<LogoutResponseDto, Error>> Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        await _signInManager.SignOutAsync();
        return Result<LogoutResponseDto, Error>.Success(new LogoutResponseDto { Message = "Logout successful." });
    }
}