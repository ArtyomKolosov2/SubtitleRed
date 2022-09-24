using SubtitleRed.Domain.Sections;

namespace SubtitleRed.Domain.Scenes;

public class Scene : Entity
{
    public string Name { get; set; }
    
    public ISectionsCollection Sections { get; set; }
}