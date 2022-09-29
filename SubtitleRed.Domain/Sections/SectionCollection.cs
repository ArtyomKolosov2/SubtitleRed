using System.Collections;
using SubtitleRed.Shared;
using SubtitleRed.Shared.Extensions;

namespace SubtitleRed.Domain.Sections;

public class SectionCollection : ISectionCollection
{
    public void Add(Section item) => AddSection(item);

    public void Clear() => _sortedSet.Clear();

    public bool Contains(Section item) => _sortedSet.Contains(item);

    public void CopyTo(Section[] array, int arrayIndex) => _sortedSet.CopyTo(array, arrayIndex);

    public bool Remove(Section item) => RemoveSection(item).IsSuccess;

    public int Count => _sortedSet.Count;

    public bool IsReadOnly => false;

    private readonly SortedSet<Section> _sortedSet;

    private static Comparer<Section> Comparer => Comparer<Section>.Create((x, y) => x.SectionOrder.CompareTo(y.SectionOrder));

    public SectionCollection(IEnumerable<Section> sections)
    {
        _sortedSet = new SortedSet<Section>(sections, Comparer);
    }

    public SectionCollection()
    {
        _sortedSet = new SortedSet<Section>(Comparer);
    }

    public IEnumerator<Section> GetEnumerator() => _sortedSet.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public Result<Section, Error> AddSection(Section section) => (section switch
    {
        { SectionOrder : 0 } => section.SetSectionOrder(_sortedSet.Count + 1),
        { SectionOrder : < 0} => Result<int, Error>.Failure(Error.WithMessage("Order value of section was less then zero.")),
        var _ => Result<int, Error>.Success(section.SectionOrder)
    }).Bind(_ =>
    {
        _sortedSet.Add(section);
        return section;
    });

    public Result<Section, Error> RemoveSection(Section section)
    {
        _sortedSet.Remove(section);
        return Result<Section, Error>.Success(section);
    }
}