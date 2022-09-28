using System.Reflection;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using SubtitleRed.Application.Lines;
using SubtitleRed.Application.Scenes;
using SubtitleRed.Application.Sections;
using SubtitleRed.Domain.Lines;
using SubtitleRed.Domain.Scenes;
using SubtitleRed.Domain.Sections;

namespace SubtitleRed.Infrastructure.Mapping;

public static class MapsterConfiguration
{
    public static void ConfigureMapster(this IServiceCollection serviceCollection)
    {
        /*TypeAdapterConfig<Scene, SceneDto>
            .NewConfig()
            .TwoWays();
        
        TypeAdapterConfig<Section, SectionDto>
            .NewConfig()
            .TwoWays();
        
        TypeAdapterConfig<Line, LineDto>
            .NewConfig()
            .TwoWays();

        TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());*/
    }
}