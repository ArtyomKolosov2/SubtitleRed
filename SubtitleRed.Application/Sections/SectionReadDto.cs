using SubtitleRed.Application.Lines;

namespace SubtitleRed.Application.Sections;

public class SectionReadDto
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public IEnumerable<LineReadDto> Lines { get; set; }

    public Guid SceneId { get; set; }
    
    public int SectionOrder { get; set; }
}