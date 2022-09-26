using SubtitleRed.Domain.Lines;
using SubtitleRed.Infrastructure.DataAccess.Context;
using SubtitleRed.Shared;

namespace SubtitleRed.Infrastructure.DataAccess.Repositories;

internal class LineRepository : Repository<Line>, ILineRepository
{
    public LineRepository(DatabaseContext context) : base(context)
    {
    }

    public Task<Result<Line, Error>> CreateLine(Line line) => 
        CreateEntity(line);

    public Task<Result<Line, Error>> GetLine(Guid id) => 
        GetEntity(id);

    public Task<Result<Line, Error>> UpdateLine(Line line) => 
        UpdateEntity(line);
}