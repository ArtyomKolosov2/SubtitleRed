using System.Collections;
using SubtitleRed.Shared;

namespace SubtitleRed.Domain.Sections;

public class SectionCollection : ISectionsCollection
{
    public int Count => _list.Count;
    
    private readonly List<Section> _list;
    
    public SectionCollection(IEnumerable<Section> sections)
    {
        _list = new List<Section>(sections);
    }

    public SectionCollection()
    {
        _list = new List<Section>();
    }

    public IEnumerator<Section> GetEnumerator() => _list.GetEnumerator();
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public Result<Section, Error> AddSection(Section section)
    {
        _list.Add(section);
        return Result<Section, Error>.Success(section);
    }

    public Result<Section, Error> RemoveSection(Section section)
    {
        _list.Remove(section);
        return Result<Section, Error>.Success(section);
    }
}