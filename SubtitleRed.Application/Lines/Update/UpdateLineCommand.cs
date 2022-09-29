using Mapster;
using MediatR;
using SubtitleRed.Domain.Lines;
using SubtitleRed.Shared;

namespace SubtitleRed.Application.Lines.Update;

public class UpdateLineCommand : IRequest<Result<LineReadDto, Error>>
{
    public Guid Id { get; }
    public Line Line { get; }

    public UpdateLineCommand(Guid id, LineDto lineDto)
    {
        Id = id;
        Line = lineDto.Adapt<Line>();
    }
}