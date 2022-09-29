using Mapster;
using MediatR;
using SubtitleRed.Domain.Sections;
using SubtitleRed.Shared;

namespace SubtitleRed.Application.Sections.Create;

public class CreateSectionCommand : IRequest<Result<SectionReadDto, Error>>
{
    public Section Section { get; }

    public CreateSectionCommand(SectionDto sectionDto)
    {
        Section = sectionDto.Adapt<Section>();
    }
}