using MediatR;
using Microsoft.AspNetCore.Identity;
using SubtitleRed.Infrastructure.Identity.JWT;
using SubtitleRed.Shared;
using SubtitleRed.Shared.Extensions;

namespace SubtitleRed.Infrastructure.Identity.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<LoginResponseDto, Error>>
{
    private readonly UserManager<IdentityUser<Guid>> _userManager;
    private readonly SignInManager<IdentityUser<Guid>> _signInManager;
    private readonly IJwtGenerator _jwtGenerator;

    public LoginCommandHandler(UserManager<IdentityUser<Guid>> userManager,
        SignInManager<IdentityUser<Guid>> signInManager,
        IJwtGenerator jwtGenerator)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtGenerator = jwtGenerator;
    }

    public async Task<Result<LoginResponseDto, Error>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.LoginRequestDto.Email);

        if (user is not null)
        {
            var result = await _signInManager.CheckPasswordSignInAsync(user, request.LoginRequestDto.Password, false);

            if (result.Succeeded)
            {
                var loginResult = _jwtGenerator.CreateJwtToken(user, await _userManager.GetRolesAsync(user)).Bind(token =>
                    new LoginResponseDto
                    {
                        Token = token
                    });

                return loginResult;
            }
        }

        return Result<LoginResponseDto, Error>.Failure(Error.WithMessage("Invalid credentials."));
    }
}