using SubtitleRed.Domain.Lines;

namespace SubtitleRed.Domain.Sections;

public class Section : Entity
{
    public ILinesCollection Lines { get; set; }
    
    public string Name { get; set; }
    
    public Guid SceneId { get; set; }
}