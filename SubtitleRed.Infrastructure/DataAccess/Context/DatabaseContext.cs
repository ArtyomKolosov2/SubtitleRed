using Microsoft.EntityFrameworkCore;
using SubtitleRed.Domain.Lines;
using SubtitleRed.Domain.Scenes;
using SubtitleRed.Domain.Sections;

namespace SubtitleRed.Infrastructure.DataAccess.Context;

public class DatabaseContext : DbContext
{
    public DbSet<Scene> Scenes { get; set; }

    public DbSet<Section> Sections { get; set; }

    public DbSet<Line> Lines { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }
}