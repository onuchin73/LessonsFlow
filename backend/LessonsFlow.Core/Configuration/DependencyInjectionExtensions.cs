using LessonsFlow.Core.EndpointsSettings;
using LessonsFlow.Core.Features.Lessons;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Exceptions;

namespace LessonsFlow.Core.Configuration;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<CreateHandler>();

        return services
            .AddSerilogLogging(configuration)
            .AddSwagger()
            .AddEndpointsApiExplorer()
            .AddEndpoints(typeof(Program).Assembly);
    }

    private static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "LessonsFlow Doc",
                Version = "v1",
                Contact = new OpenApiContact
                {
                    Name = "Anton",
                    Email = "LessonsFlow@yandex.ru",
                },
            });
        });

        return services;
    }

    public static IServiceCollection AddSerilogLogging(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSerilog((services, lc) => lc
            .ReadFrom.Configuration(configuration)
            .ReadFrom.Services(services)
            .Enrich.FromLogContext()
            .Enrich.WithExceptionDetails()
            .Enrich.WithProperty("ServiceName", "LessonService"));

        return services;
    }
}
