using Mapster;
using MediatR;
using SubtitleRed.Domain.Lines;
using SubtitleRed.Shared;

namespace SubtitleRed.Application.Lines.Create;

public class CreateLineCommand : IRequest<Result<LineDto, Error>>
{
    public Line Line { get; }
    
    public CreateLineCommand(LineDto lineDto)
    {
        Line = lineDto.Adapt<Line>();
    }
}