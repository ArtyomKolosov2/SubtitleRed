using SubtitleRed.Shared;

namespace SubtitleRed.Domain.Sections;

public interface ISectionCollection : ICollection<Section>
{
    Result<Section, Error> AddSection(Section section);

    Result<Section, Error> RemoveSection(Section section);
}