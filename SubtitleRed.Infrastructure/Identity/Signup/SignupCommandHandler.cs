using MediatR;
using Microsoft.AspNetCore.Identity;
using SubtitleRed.Infrastructure.Identity.JWT;
using SubtitleRed.Shared;
using SubtitleRed.Shared.Extensions;

namespace SubtitleRed.Infrastructure.Identity.Signup;

public class SignupCommandHandler : IRequestHandler<SignupCommand, Result<SignupResponseDto, Error>>
{
    private readonly UserManager<IdentityUser<Guid>> _userManager;
    private readonly SignInManager<IdentityUser<Guid>> _signInManager;
    private readonly IJwtGenerator _jwtGenerator;

    public SignupCommandHandler(UserManager<IdentityUser<Guid>> userManager,
        SignInManager<IdentityUser<Guid>> signInManager,
        IJwtGenerator jwtGenerator)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtGenerator = jwtGenerator;
    }

    public async Task<Result<SignupResponseDto, Error>> Handle(SignupCommand request, CancellationToken cancellationToken)
    {
        var newUser = new IdentityUser<Guid>
        {
            UserName = request.SignupRequestDto.Login,
            Email = request.SignupRequestDto.Email,
        };

        var identityResult = await _userManager.CreateAsync(newUser, request.SignupRequestDto.Password);
            
        if (identityResult.Succeeded)
        {
            await _signInManager.CheckPasswordSignInAsync(newUser, request.SignupRequestDto.Password, false);
            await _userManager.AddToRoleAsync(newUser, IdentityRoleConstants.User);

            var signupResponseResult = _jwtGenerator.CreateJwtToken(newUser, await _userManager.GetRolesAsync(newUser))
                .Bind(token => new SignupResponseDto { Token = token });
            
            return signupResponseResult;
        }

        return Result<SignupResponseDto, Error>.Failure(Error.WithMessage(string.Join(Environment.NewLine,
            identityResult.Errors.Select(x => x.Description))));
    }
}