using SubtitleRed.Domain.Sections;

namespace SubtitleRed.Domain.Scenes;

public class Scene : Entity
{
    public string Name { get; init; }

    public SectionCollection Sections { get; init; }
}