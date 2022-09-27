using SubtitleRed.Domain.Sections;

namespace SubtitleRed.Domain.Scenes;

public class Scene : Entity
{
    public Scene()
    {
        
    }
    
    public Scene(string name, SectionCollection sections)
    {
        Name = name;
        Sections = sections;
    }

    public string Name { get; init; }

    public SectionCollection Sections { get; init; }
}