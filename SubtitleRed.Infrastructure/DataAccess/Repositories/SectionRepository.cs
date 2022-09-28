using Microsoft.EntityFrameworkCore;
using SubtitleRed.Domain.Sections;
using SubtitleRed.Infrastructure.DataAccess.Context;
using SubtitleRed.Shared;

namespace SubtitleRed.Infrastructure.DataAccess.Repositories;

internal class SectionRepository : Repository<Section>, ISectionRepository
{
    private readonly DatabaseContext _databaseContext;

    public SectionRepository(DatabaseContext databaseContext) : base(databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<Result<IEnumerable<Section>, Error>> GetSectionsBySceneId(Guid sceneId)
    {
        var result = await DatabaseContext.Sections
            .AsQueryable()
            .AsNoTracking()
            .AsSplitQuery()
            .Include(x => x.Lines)
            .Where(x => x.SceneId == sceneId)
            .ToListAsync();

        return Result<IEnumerable<Section>, Error>.Success(result);
    }

    public async Task<Result<Section, Error>> GetSection(Guid id)
    {
        try
        {
            var section = await _databaseContext.Sections
                .AsQueryable()
                .AsSplitQuery()
                .AsNoTracking()
                .Include(x => x.Lines)
                .SingleAsync(x => x.Id == id);

            return Result<Section, Error>.Success(section);
        }
        catch (Exception exception)
        {
            return Result<Section, Error>.Failure(Error.WithException(exception));
        }
    }

    public Task<Result<Section, Error>> UpdateSection(Section section) =>
        UpdateEntity(section);

    public Task<Result<Section, Error>> CreateSection(Section section) =>
        CreateEntity(section);

    public Task<Result<Section, Error>> DeleteSection(Section section) => 
        DeleteEntity(section);
}