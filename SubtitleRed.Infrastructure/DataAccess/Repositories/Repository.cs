using Microsoft.EntityFrameworkCore;
using SubtitleRed.Domain;
using SubtitleRed.Infrastructure.DataAccess.Context;
using SubtitleRed.Shared;

namespace SubtitleRed.Infrastructure.DataAccess.Repositories;

internal abstract class Repository<TEntity> where TEntity : Entity
{
    protected DatabaseContext Context { get; set; }
    
    private DbSet<TEntity> EntitySet => Context.Set<TEntity>();

    protected Repository(DatabaseContext context)
    {
        Context = context;
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
        var entityEntry = await Context.AddAsync(item);
        await SaveAllAsync();
        
        return Result<TEntity, Error>.Success(entityEntry.Entity);
    }

    protected async Task<Result<TEntity, Error>> UpdateEntity(TEntity item)
    {
        Context.Entry(item).State = EntityState.Modified;
        await SaveAllAsync();
        
        return Result<TEntity, Error>.Success(item);
    }

    protected async Task<Result<TEntity, Error>> DeleteEntity(TEntity item)
    {
        var entityEntry = EntitySet.Remove(item);
        await SaveAllAsync();
        
        return Result<TEntity, Error>.Success(entityEntry.Entity);
    }

    private async Task SaveAllAsync() => 
        await Context.SaveChangesAsync();
}
