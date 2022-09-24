using SubtitleRed.Domain.Sections;

namespace SubtitleRed.Domain.Scenes;

public record Scene(string Name, ISectionsCollection Sections) : Entity<Guid>;