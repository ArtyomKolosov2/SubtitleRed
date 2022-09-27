using Mapster;
using MediatR;
using SubtitleRed.Domain.Lines;
using SubtitleRed.Shared;
using SubtitleRed.Shared.Extensions;

namespace SubtitleRed.Application.Lines.Get;

public class GetLineCommandHandler : IRequestHandler<GetLineCommand, Result<LineDto, Error>>
{
    private readonly ILineRepository _lineRepository;

    public GetLineCommandHandler(ILineRepository lineRepository)
    {
        _lineRepository = lineRepository;
    }
    
    public async Task<Result<LineDto, Error>> Handle(GetLineCommand request, CancellationToken cancellationToken) => 
        (await _lineRepository.GetLine(request.Id)).Bind(x => x.Adapt<LineDto>());
}