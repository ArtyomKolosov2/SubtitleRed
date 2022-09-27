using MediatR;
using SubtitleRed.Shared;

namespace SubtitleRed.Application.Sections.Delete;

public class DeleteSectionCommand : IRequest<Result<SectionDto, Error>>
{
    public Guid Id { get; }

    public DeleteSectionCommand(Guid id)
    {
        Id = id;
    }
}