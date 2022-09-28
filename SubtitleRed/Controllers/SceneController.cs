using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SubtitleRed.Application.Scenes;
using SubtitleRed.Application.Scenes.Create;
using SubtitleRed.Application.Scenes.Delete;
using SubtitleRed.Application.Scenes.Get;
using SubtitleRed.Application.Scenes.Update;
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
    public async Task<IActionResult> Create(SceneDto scene) =>
        (await _mediator.Send(new CreateSceneCommand(scene)))
        .To(GetResponseFromResult);

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id) =>
        (await _mediator.Send(new GetSceneCommand(id)))
            .To(GetResponseFromResult);

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] SceneDto sceneDto) =>
        (await _mediator.Send(new UpdateSceneCommand(sceneDto)))
            .To(GetResponseFromResult);
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id) =>
        (await _mediator.Send(new DeleteSceneCommand(id)))
        .To(GetResponseFromResult);

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        (await _mediator.Send(new GetSceneListCommand()))
        .To(GetResponseFromResult);
}