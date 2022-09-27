using System.ComponentModel.DataAnnotations;
using SubtitleRed.Application.Lines;

namespace SubtitleRed.Application.Sections;

public class SectionDto
{
    public Guid Id { get; set; }

    [Required] public string? Name { get; set; }

    [Required] public IEnumerable<LineDto>? Lines { get; set; }
    
    [Required] public Guid SceneId { get; set; }
}