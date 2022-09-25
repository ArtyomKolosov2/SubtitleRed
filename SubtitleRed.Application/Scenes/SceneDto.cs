using System.ComponentModel.DataAnnotations;
using SubtitleRed.Application.Sections;

namespace SubtitleRed.Application.Scenes;

public class SceneDto
{
    public Guid Id { get; set; }
    
    [Required]
    public string? Name { get; set; }
    
    [Required]
    public IEnumerable<SectionDto>? Sections { get; set; }
}