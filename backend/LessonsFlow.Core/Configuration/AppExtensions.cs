using LessonsFlow.Core.EndpointsSettings;
using Serilog;

namespace LessonsFlow.Core.Configuration;
public static class AppExtensions
{
    public static IApplicationBuilder Configure(this WebApplication app)
    {
        app.UseSerilogRequestLogging();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        RouteGroupBuilder apiGroup = app.MapGroup("/api/lessons").WithOpenApi();

        app.UseEndpoints(apiGroup);

        return app;
    }
}