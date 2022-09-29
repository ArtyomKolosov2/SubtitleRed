using MediatR;
using SubtitleRed.Shared;

namespace SubtitleRed.Application.Lines.Get;

public class GetLineCommand : IRequest<Result<LineReadDto, Error>>
{
    public Guid Id { get; }

    public GetLineCommand(Guid id)
    {
        Id = id;
    }
}