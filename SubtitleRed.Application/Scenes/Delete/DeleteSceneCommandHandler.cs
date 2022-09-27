using Mapster;
using MediatR;
using SubtitleRed.Domain.Scenes;
using SubtitleRed.Shared;
using SubtitleRed.Shared.Extensions;

namespace SubtitleRed.Application.Scenes.Delete;

public class DeleteSceneCommandHandler : IRequestHandler<DeleteSceneCommand, Result<SceneDto, Error>>
{
    private readonly ISceneRepository _sceneRepository;

    public DeleteSceneCommandHandler(ISceneRepository sceneRepository)
    {
        _sceneRepository = sceneRepository;
    }

    public async Task<Result<SceneDto, Error>> Handle(DeleteSceneCommand request, CancellationToken cancellationToken) =>
        (await (await _sceneRepository.GetScene(request.Id))
            .BindAsync(x => _sceneRepository.DeleteScene(x)))
        .Bind(line => line.Adapt<SceneDto>());
}