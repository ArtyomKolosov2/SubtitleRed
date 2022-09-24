using SubtitleRed.Domain.Locales;

namespace SubtitleRed.Domain.Lines;

public record Line(ILocalizedTextCollection Speaker, ILocalizedTextCollection Text) : Entity<Guid>
{
    public Guid SectionId { get; set; }
}