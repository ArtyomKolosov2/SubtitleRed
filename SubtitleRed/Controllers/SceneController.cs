using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SubtitleRed.Application.DTOs;
using SubtitleRed.Application.Scenes.Create;
using SubtitleRed.Shared.Extensions;

namespace SubtitleRed.Controllers;

[ApiController]
[AllowAnonymous]
public class SceneController : ControllerBase
{
    private readonly IMediator _mediator;

    public SceneController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("CreateScene")]
    public async Task<ActionResult<SceneDto>> CreateScene(SceneDto scene)
    {
        var command = new CreateSceneCommand(scene);
        return (await _mediator.Send(command)).To(x => new SceneDto
        {
            Name = x.Data.Name,
        });
    }
}