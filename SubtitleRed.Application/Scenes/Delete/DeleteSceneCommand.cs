using MediatR;
using SubtitleRed.Shared;

namespace SubtitleRed.Application.Scenes.Delete;

public class DeleteSceneCommand : IRequest<Result<SceneReadDto, Error>>
{
    public Guid Id { get; }

    public DeleteSceneCommand(Guid id)
    {
        Id = id;
    }
}