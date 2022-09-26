using Microsoft.AspNetCore.Identity;
using SubtitleRed.Infrastructure.DataAccess;
using SubtitleRed.Infrastructure.DataAccess.Repositories;
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

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var role = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
await IdentityRolesInitializer.EnsureStandardRolesCreated(role);

app.Run();