using SubtitleRed.Domain.Locales;

namespace SubtitleRed.Domain.Lines;

public class Line : Entity
{
    public Line(string speaker, ILocalizedTextCollection text, Guid sectionId)
    {
        Speaker = speaker;
        Text = text;
        SectionId = sectionId;
    }

    public string Speaker { get; } 
    
    public ILocalizedTextCollection Text { get; }
    
    public Guid SectionId { get; }
}