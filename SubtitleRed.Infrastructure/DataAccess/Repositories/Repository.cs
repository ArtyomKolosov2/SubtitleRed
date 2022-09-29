using Microsoft.EntityFrameworkCore;
using SubtitleRed.Domain;
using SubtitleRed.Infrastructure.DataAccess.Context;
using SubtitleRed.Shared;
using SubtitleRed.Shared.Extensions;

namespace SubtitleRed.Infrastructure.DataAccess.Repositories;

internal abstract class Repository<TEntity> where TEntity : Entity
{
    protected DatabaseContext DatabaseContext { get; set; }

    private DbSet<TEntity> EntitySet => DatabaseContext.Set<TEntity>();

    protected Repository(DatabaseContext databaseContext)
    {
        DatabaseContext = databaseContext;
    }

    protected async Task<Result<IEnumerable<TEntity>, Error>> GetEntityList() =>
        Result<IEnumerable<TEntity>, Error>.Success(await EntitySet.ToListAsync());

    protected async Task<Result<TEntity, Error>> GetEntity(Guid id)
    {
        var searchResult = await EntitySet.FindAsync(id);

        return searchResult is not null
            ? Result<TEntity, Error>.Success(searchResult)
            : Result<TEntity, Error>.Failure(Error.WithMessage("Item wasn't found by specified id."));
    }

    protected async Task<Result<TEntity, Error>> CreateEntity(TEntity item)
    {
        try
        {
            var entityEntry = await DatabaseContext.AddAsync(item);
            await SaveAllAsync();

            return Result<TEntity, Error>.Success(entityEntry.Entity);
        }
        catch (Exception e)
        {
            return Result<TEntity, Error>.Failure(Error.WithException(e));
        }
    }

    protected async Task<Result<TEntity, Error>> UpdateEntity(Guid id, TEntity item)
    {
        try
        {
            item.SetIdWithResult(id);
            var entity = EntitySet.Attach(item);

            return await entity.To(x => entity.Entity is null
                ? Result<TEntity, Error>.Failure(Error.WithMessage("Entity with specified id isn't found"))
                : Result<TEntity, Error>.Success(entity.Entity)).BindAsync(UpdateEntityState);
        }
        catch (Exception e)
        {
            return Result<TEntity, Error>.Failure(Error.WithException(e));
        }

        async Task<TEntity> UpdateEntityState(TEntity entity)
        {
            var update = EntitySet.Update(item);
            await SaveAllAsync();
            return update.Entity;
        }
    }

    protected async Task<Result<TEntity, Error>> DeleteEntity(TEntity item)
    {
        try
        {
            var entityEntry = EntitySet.Remove(item);
            await SaveAllAsync();

            return Result<TEntity, Error>.Success(entityEntry.Entity);
        }
        catch (Exception e)
        {
            return Result<TEntity, Error>.Failure(Error.WithException(e));
        }
    }

    private async Task SaveAllAsync() =>
        await DatabaseContext.SaveChangesAsync();
}