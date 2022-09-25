using SubtitleRed.Domain.Lines;

namespace SubtitleRed.Domain.Sections;

public class Section : Entity
{
    public Section(ILineCollection line, string name, Guid sceneId)
    {
        Line = line;
        Name = name;
        SceneId = sceneId;
    }

    public ILineCollection Line { get; }
    
    public string Name { get; }
    
    public Guid SceneId { get; }
}