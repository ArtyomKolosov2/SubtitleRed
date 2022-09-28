using System.ComponentModel.DataAnnotations;

namespace SubtitleRed.Application.Lines;

public class LineDto
{
    [Required] public Guid Id { get; set; }

    [Required] public string? Speaker { get; set; }
    
    [Required] public string? Text { get; set; }

    [Required] public Guid SectionId { get; set; }
    
    [Required]
    [Range(0, Int32.MaxValue)]
    public int LineOrder { get; set; }
}