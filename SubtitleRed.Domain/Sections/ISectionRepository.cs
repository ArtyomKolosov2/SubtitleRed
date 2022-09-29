using SubtitleRed.Shared;

namespace SubtitleRed.Domain.Sections;

public interface ISectionRepository
{
    Task<Result<IEnumerable<Section>, Error>> GetSectionsBySceneId(Guid sceneId);

    Task<Result<Section, Error>> GetSection(Guid id);

    Task<Result<Section, Error>> UpdateSection(Guid id, Section section);

    Task<Result<Section, Error>> CreateSection(Section section);

    Task<Result<Section, Error>> DeleteSection(Section section);
}