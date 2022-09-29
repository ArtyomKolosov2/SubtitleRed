using Mapster;
using MediatR;
using SubtitleRed.Domain.Scenes;
using SubtitleRed.Shared;
using SubtitleRed.Shared.Extensions;

namespace SubtitleRed.Application.Scenes.Get;

public class GetSceneCommandHandler : IRequestHandler<GetSceneCommand, Result<SceneReadDto, Error>>
{
    private readonly ISceneRepository _sceneRepository;

    public GetSceneCommandHandler(ISceneRepository sceneRepository)
    {
        _sceneRepository = sceneRepository;
    }

    public async Task<Result<SceneReadDto, Error>> Handle(GetSceneCommand request, CancellationToken cancellationToken) =>
        (await _sceneRepository.GetScene(request.Id)).Bind(x => x.Adapt<SceneReadDto>());
}