using Mapster;
using MediatR;
using SubtitleRed.Domain.Lines;
using SubtitleRed.Shared;
using SubtitleRed.Shared.Extensions;

namespace SubtitleRed.Application.Lines.Update;

public class UpdateLineCommandHandler : IRequestHandler<UpdateLineCommand, Result<LineReadDto, Error>>
{
    private readonly ILineRepository _lineRepository;

    public UpdateLineCommandHandler(ILineRepository lineRepository)
    {
        _lineRepository = lineRepository;
    }

    public async Task<Result<LineReadDto, Error>> Handle(UpdateLineCommand request, CancellationToken cancellationToken) =>
        (await _lineRepository.UpdateLine(request.Id, request.Line)).Bind(x => x.Adapt<LineReadDto>());
}