using Mapster;
using MediatR;
using SubtitleRed.Domain.Scenes;
using SubtitleRed.Shared;

namespace SubtitleRed.Application.Scenes.Update;

public class UpdateSceneCommand : IRequest<Result<SceneDto, Error>>
{
    public Scene Scene { get; }
    
    public UpdateSceneCommand(SceneDto sceneDto)
    {
        Scene = sceneDto.Adapt<Scene>();
    }
}