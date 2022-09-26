using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SubtitleRed.Application.Scenes.Create;
using SubtitleRed.Infrastructure.Identity.Login;
using SubtitleRed.Infrastructure.Identity.Logout;
using SubtitleRed.Infrastructure.Identity.Signup;

namespace SubtitleRed.Infrastructure.Mediatr;

public static class MediatrConfiguration
{
    public static IServiceCollection ConfigureMediatr(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(typeof(CreateSceneCommand));
        serviceCollection.AddMediatR(typeof(SignupCommand));
        serviceCollection.AddMediatR(typeof(LoginCommand));
        serviceCollection.AddMediatR(typeof(LogoutCommand));

        return serviceCollection;
    }
}