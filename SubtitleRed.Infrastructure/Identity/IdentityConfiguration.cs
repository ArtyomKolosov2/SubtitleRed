using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SubtitleRed.Infrastructure.Identity;

public static class IdentityConfiguration
{
    public static IServiceCollection ConfigureIdentity(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("IdentityDefaultConnection");
        serviceCollection.AddDbContext<IdentityDatabaseContext>(options => options.UseSqlServer(connectionString));
        serviceCollection.AddIdentityCore<IdentityUser<Guid>>(opts =>
            {
                opts.Password = new PasswordOptions
                {
                    RequiredLength = 6,
                    RequireNonAlphanumeric = false,
                    RequireLowercase = false,
                    RequireUppercase = false,
                    RequireDigit = false,
                };
                opts.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<IdentityDatabaseContext>();

        return serviceCollection;
    }
}