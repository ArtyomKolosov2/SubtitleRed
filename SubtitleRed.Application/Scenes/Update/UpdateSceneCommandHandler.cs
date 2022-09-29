using Mapster;
using MediatR;
using SubtitleRed.Domain.Scenes;
using SubtitleRed.Shared;
using SubtitleRed.Shared.Extensions;

namespace SubtitleRed.Application.Scenes.Update;

public class UpdateSceneCommandHandler : IRequestHandler<UpdateSceneCommand, Result<SceneReadDto, Error>>
{
    private readonly ISceneRepository _sceneRepository;

    public UpdateSceneCommandHandler(ISceneRepository sceneRepository)
    {
        _sceneRepository = sceneRepository;
    }

    public async Task<Result<SceneReadDto, Error>> Handle(UpdateSceneCommand request, CancellationToken cancellationToken) =>
        (await _sceneRepository.UpdateScene(request.Id, request.Scene)).Bind(x => x.Adapt<SceneReadDto>());
}