using Mapster;
using MediatR;
using SubtitleRed.Domain.Sections;
using SubtitleRed.Shared;

namespace SubtitleRed.Application.Sections.Update;

public class UpdateSectionCommand : IRequest<Result<SectionDto, Error>>
{
    public Section Section { get; }
    
    public UpdateSectionCommand(SectionDto sectionDto)
    {
        Section = sectionDto.Adapt<Section>();
    }
}