using SubtitleRed.Shared;

namespace SubtitleRed.Domain.Locales;

public interface ILocalizedTextCollection : IReadOnlyCollection<LocalizedText>
{
    Task<Result<LocalizedText, Error>> AddLocalizedText(LocalizedText section);

    Task<Result<LocalizedText, Error>> RemoveLocalizedText(LocalizedText section);

    Task<Result<LocalizedText, Error>> GetTextByLocale(Locale locale);
}