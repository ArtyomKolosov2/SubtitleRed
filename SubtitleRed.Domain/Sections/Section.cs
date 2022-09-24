using SubtitleRed.Domain.Lines;

namespace SubtitleRed.Domain.Sections;

public record Section(string Name, ILinesCollection Lines) : Entity<Guid>
{
    public Guid SceneId { get; set; }
}