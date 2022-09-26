using SubtitleRed.Domain.Lines;

namespace SubtitleRed.Domain.Sections;

public class Section : Entity
{
    public Section()
    {
        
    }
    
    public Section(ILineCollection line, string name, Guid sceneId)
    {
        Line = line;
        Name = name;
        SceneId = sceneId;
    }

    public ILineCollection Line { get; init; }

    public string Name { get; init; }

    public Guid SceneId { get; init; }
}