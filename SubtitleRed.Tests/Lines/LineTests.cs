using FluentAssertions;
using Flurl.Http;
using Mapster;
using SubtitleRed.Application.Lines;
using SubtitleRed.Domain.Lines;
using SubtitleRed.Domain.Scenes;
using SubtitleRed.Domain.Sections;
using Tests.EnvironmentBuilder.Base;
using Tests.EnvironmentBuilder.Fixtures;
using Tests.EnvironmentBuilder.TestCollections;
using Xunit;

namespace SubtitleRed.Tests.Lines;

[Collection(nameof(IntegrationTestCollection))]
public class LineTests : IntegrationTestsBase
{
    private const string LineControllerUrl = "Line";
    
    public LineTests(IntegrationTestFixture testFixture) : base(testFixture)
    {
    }

    [Fact]
    public async Task Create_SceneAndSectionAreCreated_LineCreatedAndResponseCorrect()
    {
        // Arrange
        var (scene, section) = CreateSceneAndSectionData();
        var lineDto = new LineDto
        {
            Text = "TestText",
            Speaker = "Test",
            SectionId = section.Id,
            LineOrder = 1
        };

        // Act
        var response = await $"{LineControllerUrl}/{CreateUrl}"
            .WithOAuthBearerToken(await GetAuthorizeToken())
            .PostJsonAsync(lineDto);

        // Assert
        var responseDto = await response.GetJsonAsync<LineDto>();
        AssertLineResponseDto(responseDto, lineDto);
    }
    
    [Fact]
    public async Task Get_LineIsCreatedAndInDatabase_LineResponseValid()
    {
        // Arrange
        var (scene, section) = CreateSceneAndSectionData();
        var line = new Line
        {
            Text = "TestText",
            Speaker = "Test",
            SectionId = section.Id,
            LineOrder = 1
        };
        line.SetId(Guid.NewGuid());
        
        TestFixture.DatabaseContext.Lines.Add(line);
        await TestFixture.DatabaseContext.SaveChangesAsync();

        // Act
        var responseDto = await $"{LineControllerUrl}/{GetUrl}/{line.Id}"
            .WithOAuthBearerToken(await GetAuthorizeToken())
            .GetJsonAsync<LineDto>();

        // Assert
        AssertLineResponseDto(responseDto, line);
    }
    
    [Fact]
    public async Task Update_LineIsCreatedAndUpdatedByRequest_LineUpdated()
    {
        // Arrange
        var (scene, section) = CreateSceneAndSectionData();
        var line = new Line
        {
            Text = "TestText",
            Speaker = "Test",
            SectionId = section.Id,
            LineOrder = 1
        };
        line.SetId(Guid.NewGuid());
        
        TestFixture.DatabaseContext.Lines.Add(line);
        await TestFixture.DatabaseContext.SaveChangesAsync();

        var lineDto = line.Adapt<LineDto>();
        lineDto.Speaker = "NewSpeaker";
        
        // Act
        var response = await $"{LineControllerUrl}/{UpdateUrl}"
            .WithOAuthBearerToken(await GetAuthorizeToken())
            .PutJsonAsync(lineDto);

        // Assert
        var responseDto = await response.GetJsonAsync<LineDto>();
        AssertLineResponseDto(responseDto, lineDto);
    }
    
    [Fact]
    public async Task Delete_LineIsCreatedAndDeletedByRequest_LineDeleted()
    {
        // Arrange
        var (scene, section) = CreateSceneAndSectionData();
        var line = new Line
        {
            Text = "TestText",
            Speaker = "Test",
            SectionId = section.Id,
            LineOrder = 1
        };
        line.SetId(Guid.NewGuid());
        
        TestFixture.DatabaseContext.Lines.Add(line);
        await TestFixture.DatabaseContext.SaveChangesAsync();
        
        // Act
        var response = await $"{LineControllerUrl}/{Delete}/{line.Id}"
            .WithOAuthBearerToken(await GetAuthorizeToken())
            .DeleteAsync();

        // Assert
        var responseDto = await response.GetJsonAsync<LineDto>();
        var entityFromDb = TestFixture.DatabaseContext.Lines.AsQueryable().SingleOrDefault(x => x.Id == responseDto.Id);
        entityFromDb.Should().BeNull();
    }
    
    private void AssertLineResponseDto(LineDto responseDto, LineDto requestDto)
    {
        responseDto.Id.Should().NotBe(Guid.Empty);
        responseDto.Speaker.Should().Be(requestDto.Speaker);
        responseDto.Text.Should().Be(requestDto.Text);
        responseDto.LineOrder.Should().Be(requestDto.LineOrder);
        
        var entityFromDb = TestFixture.DatabaseContext.Find<Line>(responseDto.Id);
        entityFromDb.Should().NotBeNull();
        TestFixture.DatabaseContext.Entry(entityFromDb).Reload();
        
        entityFromDb = TestFixture.DatabaseContext.Lines.AsQueryable().SingleOrDefault(x => x.Id == responseDto.Id);
        entityFromDb!.Speaker.Should().Be(responseDto.Speaker);
        entityFromDb.Text.Should().Be(responseDto.Text);
        entityFromDb.LineOrder.Should().Be(responseDto.LineOrder);
    }
    
    private static void AssertLineResponseDto(LineDto responseDto, Line initialLine)
    {
        responseDto.Id.Should().NotBe(Guid.Empty);
        responseDto.Speaker.Should().Be(initialLine.Speaker);
        responseDto.Text.Should().Be(initialLine.Text);
        responseDto.LineOrder.Should().Be(initialLine.LineOrder);
    }
    
    private (Scene, Section) CreateSceneAndSectionData()
    {
        var scene = new Scene
        {
            Name = "TestScene",
        };
        
        scene.SetId(Guid.NewGuid());
        
        TestFixture.DatabaseContext.Scenes.Add(scene);

        var section = new Section
        {
            Name = "TestSection",
            SceneId = scene.Id,
            SectionOrder = 1,
        };
        
        TestFixture.DatabaseContext.Sections.Add(section);
        TestFixture.DatabaseContext.SaveChanges();

        return (scene, section);
    }
}