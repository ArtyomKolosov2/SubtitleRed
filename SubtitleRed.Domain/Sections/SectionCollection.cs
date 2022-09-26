using System.Collections;
using SubtitleRed.Shared;

namespace SubtitleRed.Domain.Sections;

public class SectionCollection : ISectionCollection
{
    public void Add(Section item) => AddSection(item);

    public void Clear() => _list.Clear();

    public bool Contains(Section item) => _list.Contains(item);

    public void CopyTo(Section[] array, int arrayIndex) => _list.CopyTo(array, arrayIndex);

    public bool Remove(Section item) => RemoveSection(item).IsSuccess;
    
    public int Count => _list.Count;
    
    public bool IsReadOnly => false;

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