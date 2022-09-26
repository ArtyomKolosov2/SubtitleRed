using SubtitleRed.Domain.Scenes;
using SubtitleRed.Infrastructure.DataAccess.Context;
using SubtitleRed.Shared;

namespace SubtitleRed.Infrastructure.DataAccess.Repositories;

internal class SceneRepository : Repository<Scene>, ISceneRepository
{
    public SceneRepository(DatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public Task<Result<Scene, Error>> GetScene(Guid id) =>
        GetEntity(id);

    public Task<Result<Scene, Error>> CreateScene(Scene scene) =>
        CreateEntity(scene);
}