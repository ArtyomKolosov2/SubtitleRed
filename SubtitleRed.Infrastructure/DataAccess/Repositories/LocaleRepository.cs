using SubtitleRed.Domain.Locales;
using SubtitleRed.Infrastructure.DataAccess.Context;
using SubtitleRed.Shared;

namespace SubtitleRed.Infrastructure.DataAccess.Repositories;

internal class LocaleRepository : Repository<Locale>, ILocaleRepository
{
    public LocaleRepository(DatabaseContext context) : base(context)
    {
    }

    public Task<Result<IEnumerable<Locale>, Error>> GetLocales() =>
        GetEntityList();
}