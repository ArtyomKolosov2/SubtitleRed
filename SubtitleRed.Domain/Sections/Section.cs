using SubtitleRed.Domain.Lines;

namespace SubtitleRed.Domain.Sections;

public class Section : Entity
{
    public LineCollection Lines { get; init; }

    public string Name { get; init; }

    public Guid SceneId { get; init; }
    
    public int SectionOrder { get; init; }
}