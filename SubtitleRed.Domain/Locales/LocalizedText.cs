namespace SubtitleRed.Domain.Locales;

public class LocalizedText : Entity
{
    public LocalizedText(string text, Locale locale, Guid lineId)
    {
        Text = text;
        Locale = locale;
        LineId = lineId;
    }

    public string Text { get; }
    
    public Locale Locale { get; }
    
    public Guid LineId { get; }
}
