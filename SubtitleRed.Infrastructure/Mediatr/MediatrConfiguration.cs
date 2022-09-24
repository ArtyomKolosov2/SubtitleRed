using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SubtitleRed.Application.Scenes.Create;

namespace SubtitleRed.Infrastructure.Mediatr;

public static class MediatrConfiguration
{
    public static IServiceCollection ConfigureMediatr(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(typeof(CreateSceneCommand));
        
        return serviceCollection;
    }
}