using Mapster;
using MediatR;
using SubtitleRed.Domain.Sections;
using SubtitleRed.Shared;
using SubtitleRed.Shared.Extensions;

namespace SubtitleRed.Application.Sections.Update;

public class UpdateSectionCommandHandler : IRequestHandler<UpdateSectionCommand, Result<SectionReadDto, Error>>
{
    private readonly ISectionRepository _sectionRepository;

    public UpdateSectionCommandHandler(ISectionRepository sectionRepository)
    {
        _sectionRepository = sectionRepository;
    }

    public async Task<Result<SectionReadDto, Error>> Handle(UpdateSectionCommand request, CancellationToken cancellationToken) =>
        (await _sectionRepository.UpdateSection(request.Id, request.Section)).Bind(x => x.Adapt<SectionReadDto>());
}