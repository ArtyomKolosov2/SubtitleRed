using System.ComponentModel.DataAnnotations;

namespace SubtitleRed.Infrastructure.Identity.Signup;

public class SignupRequestDto
{
    [Required] [EmailAddress] public string Email { get; set; }

    [Required] public string Login { get; set; }

    [Required] public string Password { get; set; }
}