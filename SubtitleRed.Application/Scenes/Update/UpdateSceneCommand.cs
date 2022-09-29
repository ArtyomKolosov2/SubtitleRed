using Mapster;
using MediatR;
using SubtitleRed.Domain.Scenes;
using SubtitleRed.Shared;

namespace SubtitleRed.Application.Scenes.Update;

public class UpdateSceneCommand : IRequest<Result<SceneReadDto, Error>>
{
    public Guid Id { get; }
    public Scene Scene { get; }

    public UpdateSceneCommand(Guid id, SceneDto sceneDto)
    {
        Id = id;
        Scene = sceneDto.Adapt<Scene>();
    }
}