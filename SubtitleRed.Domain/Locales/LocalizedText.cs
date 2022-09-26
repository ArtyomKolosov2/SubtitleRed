namespace SubtitleRed.Domain.Locales;

public class LocalizedText : Entity
{
    public LocalizedText(string text, Guid localeId, Guid lineId)
    {
        Text = text;
        LocaleId = localeId;
        LineId = lineId;
    }

    public string Text { get; init; }

    public Guid LocaleId { get; init; }

    public Guid LineId { get; init; }
}