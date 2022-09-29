using System.ComponentModel.DataAnnotations;
using SubtitleRed.Application.Sections;

namespace SubtitleRed.Application.Scenes;

public class SceneDto
{
    [Required] public string? Name { get; set; }
}