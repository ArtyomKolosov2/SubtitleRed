using System.ComponentModel.DataAnnotations;
using SubtitleRed.Application.Locales;

namespace SubtitleRed.Application.Lines;

public class LocalizedTextDto
{
    [Required]
    public Guid Id { get; set; }
    
    [Required]
    public string? Text { get; set; }
    
    [Required]
    public LocaleDto? Locale { get; set; }
    
    [Required]
    public Guid LineId { get; set; }
}