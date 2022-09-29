using System.ComponentModel.DataAnnotations;

namespace SubtitleRed.Application.Sections;

public class SectionDto
{
    [Required] public string? Name { get; set; }
    
    [Required] public Guid SceneId { get; set; }

    [Required]
    [Range(1, Int32.MaxValue)]
    public int SectionOrder { get; set; }
}