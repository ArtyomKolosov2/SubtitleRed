using Mapster;
using MediatR;
using SubtitleRed.Domain.Lines;
using SubtitleRed.Shared;

namespace SubtitleRed.Application.Lines.Update;

public class UpdateLineCommand : IRequest<Result<LineDto, Error>>
{
    public Line Line { get; }
    
    public UpdateLineCommand(LineDto lineDto)
    {
        Line = lineDto.Adapt<Line>();
    }
}