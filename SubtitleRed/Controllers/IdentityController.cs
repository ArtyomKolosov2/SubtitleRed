using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SubtitleRed.Infrastructure.Identity.Login;
using SubtitleRed.Infrastructure.Identity.Logout;
using SubtitleRed.Infrastructure.Identity.Signup;
using SubtitleRed.Shared.Extensions;

namespace SubtitleRed.Controllers;

[ApiController]
[AllowAnonymous]
[Route("[action]")]
public class IdentityController : BaseApiController
{
    private readonly IMediator _mediator;

    public IdentityController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto) =>
        (await _mediator.Send(new LoginCommand(loginRequestDto))).To(GetResponseFromResult);

    [HttpPost]
    public async Task<IActionResult> Signup([FromBody] SignupRequestDto signupRequestDto) =>
        (await _mediator.Send(new SignupCommand(signupRequestDto))).To(GetResponseFromResult);

    [HttpPost]
    public async Task<IActionResult> Logout() =>
        (await _mediator.Send(new LogoutCommand())).To(GetResponseFromResult);
}