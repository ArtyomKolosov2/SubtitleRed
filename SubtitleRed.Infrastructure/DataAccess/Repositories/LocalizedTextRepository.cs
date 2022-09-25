using SubtitleRed.Domain.Locales;
using SubtitleRed.Infrastructure.DataAccess.Context;
using SubtitleRed.Shared;

namespace SubtitleRed.Infrastructure.DataAccess.Repositories;

internal class LocalizedTextRepository : Repository<LocalizedText>, ILocalizedTextRepository
{
    public LocalizedTextRepository(DatabaseContext context) : base(context)
    {
    }

    public Task<Result<LocalizedText, Error>> CreateLocalizedText(LocalizedText localizedText)
    {
        throw new NotImplementedException();
    }

    public Task<Result<IEnumerable<LocalizedText>, Error>> GetLocalizedTextByLineId(Guid lineId)
    {
        throw new NotImplementedException();
    }
}