using Microsoft.EntityFrameworkCore;
using SubtitleRed.Domain.Sections;
using SubtitleRed.Infrastructure.DataAccess.Context;
using SubtitleRed.Shared;

namespace SubtitleRed.Infrastructure.DataAccess.Repositories;

internal class SectionRepository : Repository<Section>, ISectionRepository
{
    public SectionRepository(DatabaseContext context) : base(context)
    {
    }

    public async Task<Result<IEnumerable<Section>, Error>> GetSectionsBySceneId(Guid sceneId)
    {
        var result = await Context.Sections
            .AsQueryable()
            .AsNoTracking()
            .AsSplitQuery()
            .Where(x => x.SceneId == sceneId)
            .ToListAsync();

        return Result<IEnumerable<Section>, Error>.Success(result);
    }

    public Task<Result<Section, Error>> GetSection(Guid id) =>
        GetEntity(id);

    public Task<Result<Section, Error>> UpdateSection(Section section) =>
        UpdateEntity(section);

    public Task<Result<Section, Error>> CreateSection(Section section) =>
        CreateEntity(section);
}