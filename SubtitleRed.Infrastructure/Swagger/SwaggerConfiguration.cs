using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace SubtitleRed.Infrastructure.Swagger;

public static class SwaggerConfiguration
{
    public static IServiceCollection ConfigureSwagger(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "SubtitleRed_API",
                Version = "v1",
                Description = "CD Project Red test task",
                Contact = new OpenApiContact
                {
                    Email = "artsiom.kolosov@gmail.com",
                    Name = "Artsiom Kolosov",
                    Url = new Uri("https://www.linkedin.com/in/artyom-kolosov/")
                }
            });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme."
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });

        });

        return serviceCollection;
    }
}