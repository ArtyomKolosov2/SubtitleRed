using MediatR;
using SubtitleRed.Shared;

namespace SubtitleRed.Application.Scenes.Get;

public class GetSceneCommand : IRequest<Result<SceneReadDto, Error>>
{
    public Guid Id { get; }

    public GetSceneCommand(Guid id)
    {
        Id = id;
    }
}