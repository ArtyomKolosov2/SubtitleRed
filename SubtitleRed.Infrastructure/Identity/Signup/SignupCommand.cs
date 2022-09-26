using MediatR;
using SubtitleRed.Shared;

namespace SubtitleRed.Infrastructure.Identity.Signup;

public class SignupCommand : IRequest<Result<SignupResponseDto, Error>>
{
    public SignupRequestDto SignupRequestDto { get; }

    public SignupCommand(SignupRequestDto signupRequestDto)
    {
        SignupRequestDto = signupRequestDto;
    }
}