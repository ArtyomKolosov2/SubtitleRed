using System.Collections;
using SubtitleRed.Shared;

namespace SubtitleRed.Domain.Lines;

public class LineCollection : ILineCollection
{
    public void Add(Line item) => AddLine(item);

    public void Clear() => _sortedSet.Clear();

    public bool Contains(Line item) => _sortedSet.Contains(item);

    public void CopyTo(Line[] array, int arrayIndex) => _sortedSet.CopyTo(array, arrayIndex);

    public bool Remove(Line item) => RemoveLine(item).IsSuccess;
    
    public int Count => _sortedSet.Count;
    
    public bool IsReadOnly => false;

    private readonly SortedSet<Line> _sortedSet;

    private static Comparer<Line> Comparer => Comparer<Line>.Create((x, y) => x.LineOrder.CompareTo(y.LineOrder));
    
    public LineCollection(IEnumerable<Line> sections)
    {
        _sortedSet = new SortedSet<Line>(sections, Comparer);
    }

    public LineCollection()
    {
        _sortedSet = new SortedSet<Line>(Comparer);
    }

    public IEnumerator<Line> GetEnumerator() => _sortedSet.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public Result<Line, Error> AddLine(Line section)
    {
        _sortedSet.Add(section);
        return Result<Line, Error>.Success(section);
    }

    public Result<Line, Error> RemoveLine(Line section)
    {
        _sortedSet.Remove(section);
        return Result<Line, Error>.Success(section);
    }
}