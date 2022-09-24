using Microsoft.Extensions.DependencyInjection;
using SubtitleRed.Domain.Scenes;

namespace SubtitleRed.Infrastructure.DataAccess.Repositories;

public static class RepositoriesConfiguration
{
    public static IServiceCollection ConfigureRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ISceneRepository, SceneRepository>();

        return serviceCollection;
    }
}