using SubtitleRed.Shared;

namespace SubtitleRed.Domain.Locales;

public interface ILocalizedTextCollection : IReadOnlyCollection<LocalizedText>
{
    Result<LocalizedText, Error> AddLocalizedText(LocalizedText section);

    Result<LocalizedText, Error> RemoveLocalizedText(LocalizedText section);

    Result<LocalizedText, Error> GetTextByLocale(Locale locale);
}