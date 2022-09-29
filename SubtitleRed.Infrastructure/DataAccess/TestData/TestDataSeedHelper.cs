using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SubtitleRed.Domain.Lines;
using SubtitleRed.Domain.Scenes;
using SubtitleRed.Domain.Sections;
using SubtitleRed.Infrastructure.DataAccess.Context;

namespace SubtitleRed.Infrastructure.DataAccess.TestData;

public static class TestDataSeedHelper
{
    public static async Task SeedTestDataFromJson(DatabaseContext databaseContext, ILogger logger)
    {
        try
        {
            var json = await File.ReadAllTextAsync($"{Directory.GetCurrentDirectory()}/testdata.json");
            var parsedScenes = JsonSerializer.Deserialize<IEnumerable<Scene>>(json)?.ToList() ??
                               throw new ArgumentException("Test json file was empty or not found!");
            
            if (await databaseContext.Scenes.AnyAsync())
            {
                logger.LogInformation("Test data seeding was skipped.");
                return;
            }

            var lines = parsedScenes.SelectMany(scene => scene.Sections.SelectMany(GetLinesWithSceneId)).DistinctBy(x => x.Id).ToList();
            var sections = parsedScenes.SelectMany(GetSectionsWithSceneId).DistinctBy(x => x.Id).ToList();
            
            sections.ForEach(x => x.Lines.Clear());
            parsedScenes.ForEach(x => x.Sections.Clear());
            
            await databaseContext.Scenes.AddRangeAsync(parsedScenes);
            await databaseContext.Sections.AddRangeAsync(sections);
            await databaseContext.Lines.AddRangeAsync(lines);
            
            await databaseContext.SaveChangesAsync();
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Exception occured while test data seeding.");
        }
    }

    private static IEnumerable<Line> GetLinesWithSceneId(Section section)
    {
        var lines = section.Lines.ToList();
        lines.ForEach(x => x.SectionId = section.Id);
        
        return lines;
    }

    private static IEnumerable<Section> GetSectionsWithSceneId(Scene scene)
    {
        var sections = scene.Sections.ToList();
        sections.ForEach(x => x.SceneId = scene.Id);
        
        return sections;
    }
}