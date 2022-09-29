using FluentAssertions;
using Flurl.Http;
using Mapster;
using SubtitleRed.Application.Scenes;
using SubtitleRed.Domain.Scenes;
using SubtitleRed.Domain.Sections;
using Tests.EnvironmentBuilder.Base;
using Tests.EnvironmentBuilder.Fixtures;
using Tests.EnvironmentBuilder.TestCollections;
using Xunit;

namespace SubtitleRed.Tests.Scenes;

[Collection(nameof(IntegrationTestCollection))]
public class SceneTests : IntegrationTestsBase
{
    private const string SceneControllerUrl = "Scene";

    public SceneTests(IntegrationTestFixture testFixture) : base(testFixture)
    {
    }

    [Fact]
    public async Task Create_SceneCreationRequestSent_SceneCreated()
    {
        // Arrange
        var sceneDto = new SceneDto { Name = "Test" };

        // Act
        var response = await $"{SceneControllerUrl}/{CreateUrl}"
            .WithOAuthBearerToken(await GetAuthorizeToken())
            .PostJsonAsync(sceneDto);

        // Assert
        var responseDto = await response.GetJsonAsync<SceneReadDto>();
        AssertSceneResponseDto(responseDto, sceneDto);
    }

    [Fact]
    public async Task Get_SceneIsCreatedAndInDatabase_SceneResponseValid()
    {
        // Arrange
        var scene = new Scene { Name = "Test" };

        scene.SetIdWithResult(Guid.NewGuid());

        TestFixture.DatabaseContext.Scenes.Add(scene);
        await TestFixture.DatabaseContext.SaveChangesAsync();

        // Act
        var responseDto = await $"{SceneControllerUrl}/{GetUrl}/{scene.Id}"
            .WithOAuthBearerToken(await GetAuthorizeToken())
            .GetJsonAsync<SceneReadDto>();

        // Assert
        AssertSceneResponseDto(responseDto, scene);
    }

    [Fact]
    public async Task Delete_SceneIsCreatedAndInDatabase_SceneDeletedSuccessfully()
    {
        // Arrange
        var scene = new Scene { Name = "Test" };

        scene.SetIdWithResult(Guid.NewGuid());

        TestFixture.DatabaseContext.Scenes.Add(scene);
        await TestFixture.DatabaseContext.SaveChangesAsync();

        // Act
        var response = await $"{SceneControllerUrl}/{Delete}/{scene.Id}"
            .WithOAuthBearerToken(await GetAuthorizeToken())
            .DeleteAsync();

        // Assert
        var responseDto = await response.GetJsonAsync<SceneReadDto>();
        responseDto.Id.Should().NotBeEmpty();
        var entityFromDb = TestFixture.DatabaseContext.Scenes.AsQueryable().SingleOrDefault(x => x.Id == responseDto.Id);
        entityFromDb.Should().BeNull();
    }

    [Fact]
    public async Task Update_SceneCreatedAndUpdated_UpdateSuccessful()
    {
        // Arrange
        var scene = new Scene { Name = "Test" };
        scene.SetIdWithResult(Guid.NewGuid());

        TestFixture.DatabaseContext.Scenes.Add(scene);
        await TestFixture.DatabaseContext.SaveChangesAsync();

        var requestDto = scene.Adapt<SceneDto>();
        requestDto.Name = "NewName";

        // Act
        var response = await $"{SceneControllerUrl}/{UpdateUrl}/{scene.Id}"
            .WithOAuthBearerToken(await GetAuthorizeToken())
            .PutJsonAsync(requestDto);

        // Assert
        var responseDto = await response.GetJsonAsync<SceneReadDto>();
        AssertSceneResponseDto(responseDto, requestDto);
    }

    [Fact]
    public async Task Get_SceneContainsListOfOrderedSections_SectionsAreInRightOrder()
    {
        // Arrange
        var scene = new Scene { Name = "Test" };
        scene.SetIdWithResult(Guid.NewGuid());

        var sections = new List<Section>
        {
            new() { Name = "Test2", SectionOrder = 2, SceneId = scene.Id },
            new() { Name = "Test3", SectionOrder = 3, SceneId = scene.Id },
            new() { Name = "Test1", SectionOrder = 1, SceneId = scene.Id },
        };

        sections.ForEach(x => x.SetIdWithResult(Guid.NewGuid()));

        TestFixture.DatabaseContext.Scenes.Add(scene);
        TestFixture.DatabaseContext.Sections.AddRange(sections);
        await TestFixture.DatabaseContext.SaveChangesAsync();

        // Act
        var responseDto = await $"{SceneControllerUrl}/{GetUrl}/{scene.Id}"
            .WithOAuthBearerToken(await GetAuthorizeToken())
            .GetJsonAsync<SceneReadDto>();

        // Assert
        AssertSceneResponseDto(responseDto, scene);
        responseDto.Sections.Should()
            .NotBeNullOrEmpty()
            .And.HaveSameCount(sections)
            .And.BeInAscendingOrder(x => x.SectionOrder);
    }

    private void AssertSceneResponseDto(SceneReadDto responseDto, SceneDto requestDto)
    {
        responseDto.Id.Should().NotBeEmpty();
        responseDto.Name.Should().Be(requestDto.Name);
        
        var entityFromDb = TestFixture.DatabaseContext.Find<Scene>(responseDto.Id);
        entityFromDb.Should().NotBeNull();
        TestFixture.DatabaseContext.Entry(entityFromDb).Reload();

        entityFromDb = TestFixture.DatabaseContext.Scenes.AsQueryable().SingleOrDefault(x => x.Id == responseDto.Id);
        entityFromDb!.Name.Should().Be(responseDto.Name);
    }

    private static void AssertSceneResponseDto(SceneReadDto responseDto, Scene initialScene)
    {
        responseDto.Id.Should().NotBeEmpty().And.Be(initialScene.Id);
        responseDto.Name.Should().Be(initialScene.Name);
    }
}