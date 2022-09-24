using SubtitleRed.Shared;

namespace SubtitleRed.Domain.Locales;

public interface ILocaleRepository
{
    Result<IEnumerable<Locale>, Error> GetLocales();
}