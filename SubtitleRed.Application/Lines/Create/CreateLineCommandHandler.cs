using Mapster;
using MediatR;
using SubtitleRed.Domain.Lines;
using SubtitleRed.Shared;
using SubtitleRed.Shared.Extensions;

namespace SubtitleRed.Application.Lines.Create;

public class CreateLineCommandHandler : IRequestHandler<CreateLineCommand, Result<LineReadDto, Error>>
{
    private readonly ILineRepository _lineRepository;

    public CreateLineCommandHandler(ILineRepository lineRepository)
    {
        _lineRepository = lineRepository;
    }

    public async Task<Result<LineReadDto, Error>> Handle(CreateLineCommand request, CancellationToken cancellationToken) =>
        (await _lineRepository.CreateLine(request.Line)).Bind(x => x.Adapt<LineReadDto>());
}