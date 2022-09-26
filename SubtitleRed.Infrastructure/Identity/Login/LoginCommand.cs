using MediatR;
using SubtitleRed.Shared;

namespace SubtitleRed.Infrastructure.Identity.Login;

public class LoginCommand : IRequest<Result<LoginResponseDto, Error>>
{
    public LoginRequestDto LoginRequestDto { get; }

    public LoginCommand(LoginRequestDto loginRequestDto)
    {
        LoginRequestDto = loginRequestDto;
    }
}