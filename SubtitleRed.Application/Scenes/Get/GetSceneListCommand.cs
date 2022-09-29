using MediatR;
using SubtitleRed.Domain.Scenes;
using SubtitleRed.Shared;

namespace SubtitleRed.Application.Scenes.Get;

public class GetSceneListCommand : IRequest<Result<IEnumerable<SceneReadDto>, Error>>
{
}