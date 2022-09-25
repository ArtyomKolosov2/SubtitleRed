using Microsoft.Extensions.DependencyInjection;
using SubtitleRed.Domain.Lines;
using SubtitleRed.Domain.Locales;
using SubtitleRed.Domain.Scenes;
using SubtitleRed.Domain.Sections;

namespace SubtitleRed.Infrastructure.DataAccess.Repositories;

public static class RepositoriesConfiguration
{
    public static IServiceCollection ConfigureRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ISceneRepository, SceneRepository>();
        serviceCollection.AddScoped<ISectionRepository, SectionRepository>();
        serviceCollection.AddScoped<ILineRepository, LineRepository>();
        serviceCollection.AddScoped<ILocaleRepository, LocaleRepository>();
        serviceCollection.AddScoped<ILocalizedTextRepository, LocalizedTextRepository>();

        return serviceCollection;
    }
}