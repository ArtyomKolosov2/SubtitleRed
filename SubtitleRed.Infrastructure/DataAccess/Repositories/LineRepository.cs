using SubtitleRed.Domain.Lines;
using SubtitleRed.Infrastructure.DataAccess.Context;
using SubtitleRed.Shared;

namespace SubtitleRed.Infrastructure.DataAccess.Repositories;

internal class LineRepository : Repository<Line>, ILineRepository
{
    public LineRepository(DatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public Task<Result<Line, Error>> CreateLine(Line line) =>
        CreateEntity(line);

    public Task<Result<Line, Error>> GetLine(Guid id) =>
        GetEntity(id);

    public Task<Result<Line, Error>> UpdateLine(Guid id, Line line) =>
        UpdateEntity(id, line);

    public Task<Result<Line, Error>> DeleteLine(Line line) =>
        DeleteEntity(line);
}