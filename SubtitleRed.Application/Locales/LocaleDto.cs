using System.ComponentModel.DataAnnotations;

namespace SubtitleRed.Application.Locales;

public class LocaleDto
{
    [Required]
    public Guid Id { get; set; }
    
    [Required]
    public string? TwoLetterCode { get; set; }
    
    [Required]
    public string? LanguageName { get; set; }
}