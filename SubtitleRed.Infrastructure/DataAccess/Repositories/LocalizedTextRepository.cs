using Microsoft.EntityFrameworkCore;
using SubtitleRed.Domain.Locales;
using SubtitleRed.Infrastructure.DataAccess.Context;
using SubtitleRed.Shared;

namespace SubtitleRed.Infrastructure.DataAccess.Repositories;

internal class LocalizedTextRepository : Repository<LocalizedText>, ILocalizedTextRepository
{
    public LocalizedTextRepository(DatabaseContext context) : base(context)
    {
    }

    public Task<Result<LocalizedText, Error>> CreateLocalizedText(LocalizedText localizedText) =>
        CreateEntity(localizedText);

    public async Task<Result<IEnumerable<LocalizedText>, Error>> GetLocalizedTextByLineId(Guid lineId)
    {
        var localizedTexts = await Context.LocalizedTexts
            .AsQueryable()
            .Where(x => x.LineId == lineId)
            .AsNoTracking()
            .AsSingleQuery()
            .ToListAsync();

        return Result<IEnumerable<LocalizedText>, Error>.Success(localizedTexts);
    }
}