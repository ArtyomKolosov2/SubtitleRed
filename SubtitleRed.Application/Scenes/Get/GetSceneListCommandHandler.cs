using Mapster;
using MediatR;
using SubtitleRed.Domain.Scenes;
using SubtitleRed.Shared;
using SubtitleRed.Shared.Extensions;

namespace SubtitleRed.Application.Scenes.Get;

public class GetSceneListCommandHandler : IRequestHandler<GetSceneListCommand, Result<IEnumerable<SceneReadDto>, Error>>
{
    private readonly ISceneRepository _sceneRepository;

    public GetSceneListCommandHandler(ISceneRepository sceneRepository)
    {
        _sceneRepository = sceneRepository;
    }

    public async Task<Result<IEnumerable<SceneReadDto>, Error>> Handle(GetSceneListCommand request, CancellationToken cancellationToken) =>
        (await _sceneRepository.GetAllScenes()).Bind(x => x.Adapt<IEnumerable<SceneReadDto>>());
}