using MediatR;
using SubtitleRed.Application.DTOs;
using SubtitleRed.Domain.Scenes;
using SubtitleRed.Domain.Sections;
using SubtitleRed.Shared;
using SubtitleRed.Shared.Extensions;

namespace SubtitleRed.Application.Scenes.Create;

public class CreateSceneCommand : IRequest<Result<SceneDto, Error>>
{
    public Scene Scene { get; set; }

    public CreateSceneCommand(SceneDto sceneDto)
    {
        Scene = new Scene
        {
            Name = sceneDto.Name,
            Sections = new SectionCollection(Enumerable.Empty<Section>())
        }.Do<Scene>(x => x.SetId(sceneDto.Id));
    }
}