using System.ComponentModel.DataAnnotations;

namespace SubtitleRed.Application.Lines;

public class LineDto
{
    [Required]
    public Guid Id { get; set; }
    
    [Required]
    public string? Speaker { get; set; } 
    
    [Required]
    public IEnumerable<LocalizedTextDto>? Text { get; set; }
    
    [Required]
    public Guid SectionId { get; set; }
}