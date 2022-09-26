using SubtitleRed.Shared;

namespace SubtitleRed.Domain.Lines;

public interface ILineRepository
{
    Task<Result<Line, Error>> CreateLine(Line line);

    Task<Result<Line, Error>> GetLine(Guid id);

    Task<Result<Line, Error>> UpdateLine(Line line);
}