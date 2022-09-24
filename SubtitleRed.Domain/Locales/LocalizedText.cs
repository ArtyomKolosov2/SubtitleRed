namespace SubtitleRed.Domain.Locales;

public class LocalizedText : Entity
{
    public string Text { get; set; }
    
    public Locale Locale { get; set; }
    
    public Guid LineId { get; set; }
}
