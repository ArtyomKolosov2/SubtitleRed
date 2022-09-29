using Microsoft.EntityFrameworkCore;
using SubtitleRed.Domain.Scenes;
using SubtitleRed.Infrastructure.DataAccess.Context;
using SubtitleRed.Shared;

namespace SubtitleRed.Infrastructure.DataAccess.Repositories;

internal class SceneRepository : Repository<Scene>, ISceneRepository
{
    private readonly DatabaseContext _databaseContext;

    public SceneRepository(DatabaseContext databaseContext) : base(databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<Result<Scene, Error>> GetScene(Guid id)
    {
        try
        {
            var scene = await _databaseContext.Scenes
                .AsQueryable()
                .AsSplitQuery()
                .AsNoTracking()
                .Include(x => x.Sections)
                .ThenInclude(x => x.Lines)
                .SingleAsync(x => x.Id == id);

            return Result<Scene, Error>.Success(scene);
        }
        catch (Exception exception)
        {
            return Result<Scene, Error>.Failure(Error.WithException(exception));
        }
    }

    public Task<Result<Scene, Error>> CreateScene(Scene scene) =>
        CreateEntity(scene);

    public Task<Result<Scene, Error>> UpdateScene(Guid id, Scene scene) =>
        UpdateEntity(id, scene);

    public Task<Result<Scene, Error>> DeleteScene(Scene scene) =>
        DeleteEntity(scene);

    public async Task<Result<IEnumerable<Scene>, Error>> GetAllScenes()
    {
        try
        {
            var scenes = await _databaseContext.Scenes
                .AsQueryable()
                .AsSplitQuery()
                .AsNoTracking()
                .Include(x => x.Sections)
                .ThenInclude(x => x.Lines)
                .ToListAsync();

            return Result<IEnumerable<Scene>, Error>.Success(scenes);
        }
        catch (Exception exception)
        {
            return Result<IEnumerable<Scene>, Error>.Failure(Error.WithException(exception));
        }
    }
}