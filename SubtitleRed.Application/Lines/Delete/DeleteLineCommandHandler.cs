using Mapster;
using MediatR;
using SubtitleRed.Domain.Lines;
using SubtitleRed.Shared;
using SubtitleRed.Shared.Extensions;

namespace SubtitleRed.Application.Lines.Delete;

public class DeleteLineCommandHandler : IRequestHandler<DeleteLineCommand, Result<LineReadDto, Error>>
{
    private readonly ILineRepository _lineRepository;

    public DeleteLineCommandHandler(ILineRepository lineRepository)
    {
        _lineRepository = lineRepository;
    }

    public async Task<Result<LineReadDto, Error>> Handle(DeleteLineCommand request, CancellationToken cancellationToken) =>
        (await (await _lineRepository.GetLine(request.Id))
            .BindAsync(x => _lineRepository.DeleteLine(x)))
        .Bind(line => line.Adapt<LineReadDto>());
}