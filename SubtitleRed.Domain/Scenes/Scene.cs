using SubtitleRed.Domain.Sections;

namespace SubtitleRed.Domain.Scenes;

public class Scene : Entity
{
    public Scene(string name, ISectionCollection section)
    {
        Name = name;
        Section = section;
    }

    public string Name { get; }
    
    public ISectionCollection Section { get; }
}