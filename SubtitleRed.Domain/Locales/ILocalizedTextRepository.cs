using SubtitleRed.Shared;

namespace SubtitleRed.Domain.Locales;

public interface ILocalizedTextRepository
{
    Task<Result<LocalizedText, Error>> CreateLocalizedText(LocalizedText localizedText);

    Task<Result<IEnumerable<LocalizedText>, Error>> GetLocalizedTextByLineId(Guid lineId);
}