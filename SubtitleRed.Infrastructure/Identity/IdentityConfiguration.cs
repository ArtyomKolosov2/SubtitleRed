using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SubtitleRed.Infrastructure.Identity.JWT;

namespace SubtitleRed.Infrastructure.Identity;

public static class IdentityConfiguration
{
    public static IServiceCollection ConfigureIdentity(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var connectionString = configuration["DatabaseSettings:IdentityDefaultConnection"];
        serviceCollection.AddDbContext<IdentityDatabaseContext>(options => options.UseSqlServer(connectionString));
        serviceCollection.AddIdentity<IdentityUser<Guid>, IdentityRole<Guid>>(opts =>
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
        
        serviceCollection.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                var validator = new JwtTokenValidatorService(configuration);
                x.SecurityTokenValidators.Add(validator);
            });
        
        serviceCollection.AddAuthorization();
        serviceCollection.AddScoped<JwtGenerator>();

        return serviceCollection;
    }
}