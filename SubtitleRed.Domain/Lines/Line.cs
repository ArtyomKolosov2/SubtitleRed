using SubtitleRed.Domain.Locales;

namespace SubtitleRed.Domain.Lines;

public class Line : Entity
{
    public Line()
    {
        
    }
    
    public Line(string speaker, LocalizedTextCollection text, Guid sectionId)
    {
        Speaker = speaker;
        Text = text;
        SectionId = sectionId;
    }

    public string Speaker { get; init; }

    public LocalizedTextCollection Text { get; init; }

    public Guid SectionId { get; init; }
}