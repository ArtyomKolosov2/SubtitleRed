using SubtitleRed.Shared;

namespace SubtitleRed.Domain.Scenes;

public interface ISceneRepository
{
    Task<Result<Scene, Error>> GetScene(Guid id);

    Task<Result<Scene, Error>> CreateScene(Scene scene);
    
    Task<Result<Scene, Error>> UpdateScene(Scene scene);
    
    Task<Result<Scene, Error>> DeleteScene(Scene scene);

    Task<Result<IEnumerable<Scene>, Error>> GetAllScenes();
}