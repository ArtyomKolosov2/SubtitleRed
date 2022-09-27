using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SubtitleRed.Application.Sections;
using SubtitleRed.Application.Sections.Create;
using SubtitleRed.Application.Sections.Delete;
using SubtitleRed.Application.Sections.Get;
using SubtitleRed.Application.Sections.Update;
using SubtitleRed.Shared.Extensions;

namespace SubtitleRed.Controllers;

[ApiController]
[Authorize]
[Route("[controller]/[action]")]
public class SectionController : BaseApiController
{
    private readonly IMediator _mediator;

    public SectionController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(SectionDto sectionDto) =>
        (await _mediator.Send(new CreateSectionCommand(sectionDto)))
        .To(GetResponseFromResult);

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id) =>
        (await _mediator.Send(new GetSectionCommand(id)))
        .To(GetResponseFromResult);

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] SectionDto sectionDto) =>
        (await _mediator.Send(new UpdateSectionCommand(sectionDto)))
        .To(GetResponseFromResult);
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id) =>
        (await _mediator.Send(new DeleteSectionCommand(id)))
        .To(GetResponseFromResult);
}