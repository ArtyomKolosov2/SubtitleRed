using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SubtitleRed.Infrastructure.DataAccess.Context;
using SubtitleRed.Infrastructure.Identity;

namespace Tests.EnvironmentBuilder.ApplicationFactory;

public class TestApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var databaseDescriptor = services.Single(d => d.ServiceType == typeof(DbContextOptions<DatabaseContext>));
            var identityDatabaseDescriptor = services.Single(d => d.ServiceType == typeof(DbContextOptions<IdentityDatabaseContext>));

            services.Remove(databaseDescriptor);
            services.Remove(identityDatabaseDescriptor);
            
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseInMemoryDatabase($"Database");
            });
            services.AddDbContext<IdentityDatabaseContext>(options =>
            {
                options.UseInMemoryDatabase($"IdentityDatabase");
            });
   
            var serviceProvider = services.BuildServiceProvider();

            using var scope = serviceProvider.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<DatabaseContext>();
            var identityDb = scopedServices.GetRequiredService<IdentityDatabaseContext>();
            var roleManagementService = scopedServices.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            db.Database.EnsureCreated();
            identityDb.Database.EnsureCreated();
            
            IdentityRolesInitializer.EnsureStandardRolesCreated(roleManagementService).GetAwaiter().GetResult();
        });
    }
}