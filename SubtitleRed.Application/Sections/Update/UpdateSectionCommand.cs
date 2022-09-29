using Mapster;
using MediatR;
using SubtitleRed.Domain.Sections;
using SubtitleRed.Shared;

namespace SubtitleRed.Application.Sections.Update;

public class UpdateSectionCommand : IRequest<Result<SectionReadDto, Error>>
{
    public Guid Id { get; }
    public Section Section { get; }

    public UpdateSectionCommand(Guid id, SectionDto sectionDto)
    {
        Id = id;
        Section = sectionDto.Adapt<Section>();
    }
}