using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SubtitleRed.Application.Lines.Create;
using SubtitleRed.Application.Lines.Delete;
using SubtitleRed.Application.Lines.Get;
using SubtitleRed.Application.Lines.Update;
using SubtitleRed.Application.Scenes.Create;
using SubtitleRed.Application.Scenes.Delete;
using SubtitleRed.Application.Scenes.Get;
using SubtitleRed.Application.Scenes.Update;
using SubtitleRed.Application.Sections.Create;
using SubtitleRed.Application.Sections.Delete;
using SubtitleRed.Application.Sections.Get;
using SubtitleRed.Application.Sections.Update;
using SubtitleRed.Infrastructure.Identity.Login;
using SubtitleRed.Infrastructure.Identity.Logout;
using SubtitleRed.Infrastructure.Identity.Signup;

namespace SubtitleRed.Infrastructure.Mediatr;

public static class MediatrConfiguration
{
    public static IServiceCollection ConfigureMediatr(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(typeof(CreateSceneCommand));
        serviceCollection.AddMediatR(typeof(GetSceneCommand));
        serviceCollection.AddMediatR(typeof(GetSceneListCommand));
        serviceCollection.AddMediatR(typeof(UpdateSceneCommand));
        serviceCollection.AddMediatR(typeof(DeleteSceneCommand));

        serviceCollection.AddMediatR(typeof(CreateLineCommand));
        serviceCollection.AddMediatR(typeof(GetLineCommand));
        serviceCollection.AddMediatR(typeof(UpdateLineCommand));
        serviceCollection.AddMediatR(typeof(DeleteLineCommand));

        serviceCollection.AddMediatR(typeof(CreateSectionCommand));
        serviceCollection.AddMediatR(typeof(GetSectionCommand));
        serviceCollection.AddMediatR(typeof(UpdateSectionCommand));
        serviceCollection.AddMediatR(typeof(DeleteSectionCommand));

        serviceCollection.AddMediatR(typeof(SignupCommand));
        serviceCollection.AddMediatR(typeof(LoginCommand));
        serviceCollection.AddMediatR(typeof(LogoutCommand));

        return serviceCollection;
    }
}