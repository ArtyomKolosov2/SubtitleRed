using System.ComponentModel.DataAnnotations;
using SubtitleRed.Application.Lines;

namespace SubtitleRed.Application.Sections;

public class SectionDto
{
    public Guid Id { get; set; }

    [Required] public string? Name { get; set; }

    public IEnumerable<LineDto>? Lines { get; set; }
    
    [Required] public Guid SceneId { get; set; }
    
    [Required]
    [Range(0, Int32.MaxValue)]
    public int SectionOrder { get; set; }
}