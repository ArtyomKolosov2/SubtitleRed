using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SubtitleRed.Infrastructure.DataAccess.Context;
using SubtitleRed.Infrastructure.DataAccess.Repositories;
using SubtitleRed.Infrastructure.Identity;
using SubtitleRed.Infrastructure.Mediatr;
using SubtitleRed.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var connectionString = builder.Configuration["DatabaseSettings:DefaultConnection"];
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString, s => s.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));
builder.Services.ConfigureIdentity(builder.Configuration);
builder.Services.ConfigureMediatr();
builder.Services.ConfigureRepositories();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
