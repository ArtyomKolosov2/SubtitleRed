using SubtitleRed.Shared;

namespace SubtitleRed.Domain.Sections;

public interface ISectionsRepository
{
    Result<IEnumerable<Section>, Error> GetSectionsBySceneId(Guid sceneId);

    Result<Section, Error> GetSection(Guid id);

    Result<Section, Error> UpdateSection(Section section);

    Result<Section, Error> CreateSection(Section section);
}