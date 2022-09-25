using SubtitleRed.Shared;

namespace SubtitleRed.Domain.Locales;

public interface ILocaleRepository
{
    Task<Result<IEnumerable<Locale>, Error>> GetLocales();
}