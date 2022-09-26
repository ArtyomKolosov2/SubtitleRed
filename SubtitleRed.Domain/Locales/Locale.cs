namespace SubtitleRed.Domain.Locales;

public class Locale : Entity
{
    public Locale(string twoLetterCode, string languageName)
    {
        TwoLetterCode = twoLetterCode;
        LanguageName = languageName;
    }

    public string TwoLetterCode { get; init; }

    public string LanguageName { get; init; }
}