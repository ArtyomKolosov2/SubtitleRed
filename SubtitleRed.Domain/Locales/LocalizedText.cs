namespace SubtitleRed.Domain.Locales;

public record LocalizedText(Locale Locale, string Text) : Entity<Guid>
{
    public Guid LineId { get; set; }
}
