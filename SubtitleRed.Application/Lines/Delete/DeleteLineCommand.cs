using MediatR;
using SubtitleRed.Shared;

namespace SubtitleRed.Application.Lines.Delete;

public class DeleteLineCommand : IRequest<Result<LineReadDto, Error>>
{
    public Guid Id { get; }

    public DeleteLineCommand(Guid id)
    {
        Id = id;
    }
}