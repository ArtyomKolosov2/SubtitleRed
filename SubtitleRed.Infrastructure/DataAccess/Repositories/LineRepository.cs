using SubtitleRed.Domain.Lines;
using SubtitleRed.Infrastructure.DataAccess.Context;
using SubtitleRed.Shared;

namespace SubtitleRed.Infrastructure.DataAccess.Repositories;

internal class LineRepository : Repository<Line>, ILineRepository
{
    public LineRepository(DatabaseContext context) : base(context)
    {
    }

    public Task<Result<Line, Error>> CreateLine(Line line)
    {
        throw new NotImplementedException();
    }

    public Task<Result<Line, Error>> GetLine(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<Line, Error>> UpdateLine(Line line)
    {
        throw new NotImplementedException();
    }
}