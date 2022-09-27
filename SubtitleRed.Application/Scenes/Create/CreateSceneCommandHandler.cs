﻿using Mapster;
using MediatR;
using SubtitleRed.Domain.Scenes;
using SubtitleRed.Shared;
using SubtitleRed.Shared.Extensions;

namespace SubtitleRed.Application.Scenes.Create;

public class CreateSceneCommandHandler : IRequestHandler<CreateSceneCommand, Result<SceneDto, Error>>
{
    private readonly ISceneRepository _sceneRepository;

    public CreateSceneCommandHandler(ISceneRepository sceneRepository)
    {
        _sceneRepository = sceneRepository;
    }

    public async Task<Result<SceneDto, Error>> Handle(CreateSceneCommand request, CancellationToken cancellationToken) => 
        (await _sceneRepository.CreateScene(request.Scene)).Bind(x => x.Adapt<SceneDto>());
}