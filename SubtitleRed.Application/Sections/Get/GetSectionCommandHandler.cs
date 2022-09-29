using Mapster;
using MediatR;
using SubtitleRed.Domain.Sections;
using SubtitleRed.Shared;
using SubtitleRed.Shared.Extensions;

namespace SubtitleRed.Application.Sections.Get;

public class GetSectionCommandHandler : IRequestHandler<GetSectionCommand, Result<SectionReadDto, Error>>
{
    private readonly ISectionRepository _sectionRepository;

    public GetSectionCommandHandler(ISectionRepository sectionRepository)
    {
        _sectionRepository = sectionRepository;
    }

    public async Task<Result<SectionReadDto, Error>> Handle(GetSectionCommand request, CancellationToken cancellationToken) =>
        (await _sectionRepository.GetSection(request.Id)).Bind(x => x.Adapt<SectionReadDto>());
}