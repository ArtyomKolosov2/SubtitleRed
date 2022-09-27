using Mapster;
using MediatR;
using SubtitleRed.Domain.Sections;
using SubtitleRed.Shared;
using SubtitleRed.Shared.Extensions;

namespace SubtitleRed.Application.Sections.Create;

public class CreateSectionCommandHandler : IRequestHandler<CreateSectionCommand, Result<SectionDto, Error>>
{
    private readonly ISectionRepository _sectionRepository;

    public CreateSectionCommandHandler(ISectionRepository sectionRepository)
    {
        _sectionRepository = sectionRepository;
    }
    
    public async Task<Result<SectionDto, Error>> Handle(CreateSectionCommand request, CancellationToken cancellationToken) => 
        (await _sectionRepository.CreateSection(request.Section)).Bind(x => x.Adapt<SectionDto>());
}