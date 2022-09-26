using System.ComponentModel.DataAnnotations;

namespace SubtitleRed.Infrastructure.Identity.Login;

public class LoginRequestDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}
