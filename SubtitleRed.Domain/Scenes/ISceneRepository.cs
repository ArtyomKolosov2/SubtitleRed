using SubtitleRed.Shared;

namespace SubtitleRed.Domain.Scenes;

public interface ISceneRepository
{
    Task<Result<Scene, Error>> GetScene(Guid id);

    Task<Result<Scene, Error>> CreateScene(Scene scene);
}