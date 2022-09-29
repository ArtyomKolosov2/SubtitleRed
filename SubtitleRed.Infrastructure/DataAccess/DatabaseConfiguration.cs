using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SubtitleRed.Infrastructure.DataAccess.Context;

namespace SubtitleRed.Infrastructure.DataAccess;

public static class DatabaseConfiguration
{
    public static IServiceCollection ConfigureDatabase(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var connectionString = configuration["DatabaseSettings:DefaultConnection"];
        serviceCollection.AddDbContext<DatabaseContext>(options =>
            options.UseSqlServer(connectionString, s => s.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));

        return serviceCollection;
    }
}