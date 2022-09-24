
namespace SubtitleRed.Domain.Locales;

public record Locale(string TwoLetterCode, string LanguageName) : Entity<Guid>;
