using System.Collections;
using SubtitleRed.Shared;
using SubtitleRed.Shared.Extensions;

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

    public Result<Line, Error> AddLine(Line line) => (line switch
    {
        { LineOrder : 0 } => line.SetLineOrder(_sortedSet.Count + 1),
        { LineOrder : < 0} => Result<int, Error>.Failure(Error.WithMessage("Order value of line was less then zero.")),
        var _ => Result<int, Error>.Success(line.LineOrder)
    }).Bind(_ =>
    {
        _sortedSet.Add(line);
        return line;
    });

    public Result<Line, Error> RemoveLine(Line section)
    {
        _sortedSet.Remove(section);
        return Result<Line, Error>.Success(section);
    }
}