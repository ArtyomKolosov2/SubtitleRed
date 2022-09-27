using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SubtitleRed.Application.Lines;
using SubtitleRed.Application.Lines.Create;
using SubtitleRed.Application.Lines.Delete;
using SubtitleRed.Application.Lines.Get;
using SubtitleRed.Application.Lines.Update;
using SubtitleRed.Shared.Extensions;

namespace SubtitleRed.Controllers;

[ApiController]
[Authorize]
[Route("[controller]/[action]")]
public class LineController : BaseApiController
{
    private readonly IMediator _mediator;

    public LineController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(LineDto lineDto) =>
        (await _mediator.Send(new CreateLineCommand(lineDto)))
        .To(GetResponseFromResult);

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id) =>
        (await _mediator.Send(new GetLineCommand(id)))
        .To(GetResponseFromResult);

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] LineDto lineDto) =>
        (await _mediator.Send(new UpdateLineCommand(lineDto)))
        .To(GetResponseFromResult);
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id) =>
        (await _mediator.Send(new DeleteLineCommand(id)))
        .To(GetResponseFromResult);
}