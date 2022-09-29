using FluentAssertions;
using Flurl.Http;
using Mapster;
using SubtitleRed.Application.Sections;
using SubtitleRed.Domain.Lines;
using SubtitleRed.Domain.Sections;
using Tests.EnvironmentBuilder.Base;
using Tests.EnvironmentBuilder.Fixtures;
using Tests.EnvironmentBuilder.TestCollections;
using Xunit;

namespace SubtitleRed.Tests.Sections;

[Collection(nameof(IntegrationTestCollection))]
public class SectionTests : IntegrationTestsBase
{
    private const string SectionControllerUrl = "Section";

    public SectionTests(IntegrationTestFixture testFixture) : base(testFixture)
    {
    }

    [Fact]
    public async Task Create_SectionCreationRequestSent_SectionCreated()
    {
        // Arrange
        var sectionDto = new SectionDto
        {
            SceneId = Guid.NewGuid(),
            Name = "Test",
            SectionOrder = 1,
        };

        // Act
        var response = await $"{SectionControllerUrl}/{CreateUrl}"
            .WithOAuthBearerToken(await GetAuthorizeToken())
            .PostJsonAsync(sectionDto);

        // Assert
        var responseDto = await response.GetJsonAsync<SectionReadDto>();
        AssertSectionResponseDto(responseDto, sectionDto);
    }

    [Fact]
    public async Task Get_SectionIsCreatedAndInDatabase_SectionResponseValid()
    {
        // Arrange
        var section = new Section { Name = "Test" };

        section.SetIdWithResult(Guid.NewGuid());

        TestFixture.DatabaseContext.Sections.Add(section);
        await TestFixture.DatabaseContext.SaveChangesAsync();

        // Act
        var responseDto = await $"{SectionControllerUrl}/{GetUrl}/{section.Id}"
            .WithOAuthBearerToken(await GetAuthorizeToken())
            .GetJsonAsync<SectionReadDto>();

        // Assert
        AssertSectionResponseDto(responseDto, section);
    }

    [Fact]
    public async Task Delete_SectionIsCreatedAndInDatabase_SectionDeletedSuccessfully()
    {
        // Arrange
        var section = new Section { Name = "Test" };

        section.SetIdWithResult(Guid.NewGuid());

        TestFixture.DatabaseContext.Sections.Add(section);
        await TestFixture.DatabaseContext.SaveChangesAsync();

        // Act
        var response = await $"{SectionControllerUrl}/{Delete}/{section.Id}"
            .WithOAuthBearerToken(await GetAuthorizeToken())
            .DeleteAsync();

        // Assert
        var responseDto = await response.GetJsonAsync<SectionReadDto>();
        responseDto.Id.Should().NotBeEmpty();
        var entityFromDb = TestFixture.DatabaseContext.Sections.AsQueryable().SingleOrDefault(x => x.Id == responseDto.Id);
        entityFromDb.Should().BeNull();
    }

    [Fact]
    public async Task Update_SectionCreatedAndUpdated_UpdateSuccessful()
    {
        // Arrange
        var section = new Section
        {
            SceneId = Guid.NewGuid(),
            Name = "Test",
            SectionOrder = 1,
        };
        section.SetIdWithResult(Guid.NewGuid());

        TestFixture.DatabaseContext.Sections.Add(section);
        await TestFixture.DatabaseContext.SaveChangesAsync();

        var requestDto = section.Adapt<SectionDto>();
        requestDto.Name = "NewName";

        // Act
        var response = await $"{SectionControllerUrl}/{UpdateUrl}/{section.Id}"
            .WithOAuthBearerToken(await GetAuthorizeToken())
            .PutJsonAsync(requestDto);

        // Assert
        var responseDto = await response.GetJsonAsync<SectionReadDto>();
        AssertSectionResponseDto(responseDto, requestDto);
    }

    [Fact]
    public async Task Get_SectionContainsListOfOrderedLines_LinesAreInRightOrder()
    {
        // Arrange
        var section = new Section { Name = "Test" };
        section.SetIdWithResult(Guid.NewGuid());

        var lines = new Line[]
        {
            new() { Speaker = "Test2", Text = "Test", LineOrder = 2, SectionId = section.Id },
            new() { Speaker = "Test3", Text = "Test", LineOrder = 3, SectionId = section.Id },
            new() { Speaker = "Test1", Text = "Test", LineOrder = 1, SectionId = section.Id },
        };

        foreach (var line in lines)
        {
            line.Id = Guid.NewGuid();
        }

        TestFixture.DatabaseContext.Sections.Add(section);
        TestFixture.DatabaseContext.Lines.AddRange(lines);
        await TestFixture.DatabaseContext.SaveChangesAsync();

        // Act
        var responseDto = await $"{SectionControllerUrl}/{GetUrl}/{section.Id}"
            .WithOAuthBearerToken(await GetAuthorizeToken())
            .GetJsonAsync<SectionReadDto>();

        // Assert
        AssertSectionResponseDto(responseDto, section);
        responseDto.Lines.Should()
            .NotBeNullOrEmpty()
            .And.HaveSameCount(lines)
            .And.BeInAscendingOrder(x => x.LineOrder);
    }

    private void AssertSectionResponseDto(SectionReadDto responseDto, SectionDto requestDto)
    {
        responseDto.Id.Should().NotBeEmpty();
        responseDto.Name.Should().Be(requestDto.Name);

        var entityFromDb = TestFixture.DatabaseContext.Find<Section>(responseDto.Id);
        entityFromDb.Should().NotBeNull();
        TestFixture.DatabaseContext.Entry(entityFromDb).Reload();

        entityFromDb = TestFixture.DatabaseContext.Sections.AsQueryable().SingleOrDefault(x => x.Id == responseDto.Id);
        entityFromDb!.Name.Should().Be(responseDto.Name);
    }

    private static void AssertSectionResponseDto(SectionReadDto responseDto, Section initialSection)
    {
        responseDto.Id.Should().NotBeEmpty().And.Be(initialSection.Id);
        responseDto.Name.Should().Be(initialSection.Name);
    }
}