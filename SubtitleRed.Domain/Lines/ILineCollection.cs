using SubtitleRed.Shared;

namespace SubtitleRed.Domain.Lines;

public interface ILineCollection : ICollection<Line>
{
    Result<Line, Error> AddLine(Line line);

    Result<Line, Error> RemoveLine(Line line);
}