using Microsoft.AspNetCore.Identity;
using SubtitleRed.Infrastructure.DataAccess;
using SubtitleRed.Infrastructure.DataAccess.Context;
using SubtitleRed.Infrastructure.DataAccess.Repositories;
using SubtitleRed.Infrastructure.DataAccess.TestData;
using SubtitleRed.Infrastructure.Identity;
using SubtitleRed.Infrastructure.Mediatr;
using SubtitleRed.Infrastructure.Swagger;
using SubtitleRed.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services
    .ConfigureIdentity(builder.Configuration)
    .ConfigureMediatr()
    .ConfigureDatabase(builder.Configuration)
    .ConfigureRepositories()
    .ConfigureSwagger();

builder.Services.AddLogging();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
using var scope = app.Services.CreateScope();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    var loggerFactory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();
    var databaseContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    await TestDataSeedHelper.SeedTestDataFromJson(databaseContext, loggerFactory.CreateLogger(typeof(TestDataSeedHelper)));
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

var role = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
await IdentityRolesInitializer.EnsureStandardRolesCreated(role);

await app.RunAsync();

public partial class Program
{
}