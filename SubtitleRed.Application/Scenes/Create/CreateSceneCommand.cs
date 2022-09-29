using Mapster;
using MediatR;
using SubtitleRed.Domain.Scenes;
using SubtitleRed.Shared;

namespace SubtitleRed.Application.Scenes.Create;

public class CreateSceneCommand : IRequest<Result<SceneReadDto, Error>>
{
    public Scene Scene { get; }

    public CreateSceneCommand(SceneDto sceneDto)
    {
        Scene = sceneDto.Adapt<Scene>();
    }
}