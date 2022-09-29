using SubtitleRed.Application.Sections;

namespace SubtitleRed.Application.Scenes;

public class SceneReadDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public IEnumerable<SectionReadDto> Sections { get; set; }
}