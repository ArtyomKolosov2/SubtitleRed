using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SubtitleRed.Application.Scenes;
using SubtitleRed.Application.Scenes.Create;
using SubtitleRed.Shared.Extensions;

namespace SubtitleRed.Controllers;

[ApiController]
[Authorize]
[Route("[controller]/[action]")]
public class SceneController : BaseApiController
{
    private readonly IMediator _mediator;

    public SceneController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(SceneDto scene)
    {
        var command = new CreateSceneCommand(scene);
        return (await _mediator.Send(command))
            .Bind(x => new SceneDto { Name = x.Name })
            .To(GetResponseFromResult);
    }
}