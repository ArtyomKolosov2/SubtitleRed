using SubtitleRed.Domain.Sections;

namespace SubtitleRed.Domain.Scenes;

public class Scene : Entity
{
    public Scene()
    {
        
    }
    
    public Scene(string name, SectionCollection section)
    {
        Name = name;
        Section = section;
    }

    public string Name { get; init; }

    public SectionCollection Section { get; init; }
}