using MediatR;
using SubtitleRed.Shared;

namespace SubtitleRed.Application.Sections.Get;

public class GetSectionCommand : IRequest<Result<SectionDto, Error>>
{
    public Guid Id { get; }

    public GetSectionCommand(Guid id)
    {
        Id = id;
    }
}