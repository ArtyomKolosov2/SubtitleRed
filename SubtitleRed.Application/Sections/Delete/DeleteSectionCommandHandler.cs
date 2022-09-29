using Mapster;
using MediatR;
using SubtitleRed.Application.Scenes;
using SubtitleRed.Domain.Sections;
using SubtitleRed.Shared;
using SubtitleRed.Shared.Extensions;

namespace SubtitleRed.Application.Sections.Delete;

public class DeleteSectionCommandHandler : IRequestHandler<DeleteSectionCommand, Result<SectionReadDto, Error>>
{
    private readonly ISectionRepository _sectionRepository;

    public DeleteSectionCommandHandler(ISectionRepository sectionRepository)
    {
        _sectionRepository = sectionRepository;
    }

    public async Task<Result<SectionReadDto, Error>> Handle(DeleteSectionCommand request, CancellationToken cancellationToken) =>
        (await (await _sectionRepository.GetSection(request.Id))
            .BindAsync(x => _sectionRepository.DeleteSection(x)))
        .Bind(line => line.Adapt<SectionReadDto>());
}