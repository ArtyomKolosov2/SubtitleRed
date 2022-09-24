using SubtitleRed.Shared;

namespace SubtitleRed.Domain.Lines;

public interface ILinesCollection : IReadOnlyCollection<Line>
{
    Result<Line, Error> AddLine(Line line);

    Result<Line, Error> RemoveLine(Line line);
}