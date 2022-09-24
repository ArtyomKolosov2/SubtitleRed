using SubtitleRed.Domain.Locales;

namespace SubtitleRed.Domain.Lines;

public class Line : Entity
{
    public string Speaker { get; set; } 
    
    public ILocalizedTextCollection Text { get; set; }
    
    public Guid SectionId { get; set; }
}