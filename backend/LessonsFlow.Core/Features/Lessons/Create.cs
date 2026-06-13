using LessonsFlow.Core.EndpointsSettings;

namespace LessonsFlow.Core.Features.Lessons;

public sealed class Create : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("lessons", async (CreateHandler handler) =>
        {
            await handler.Handle();
        });
    }
}

public sealed class CreateHandler
{
    private readonly ILogger<CreateHandler> _logger;

    public CreateHandler(ILogger<CreateHandler> logger)
    {
        _logger = logger;
    }

    public async Task Handle()
    {
        _logger.LogInformation("Creating a new lesson");

        await Task.Delay(TimeSpan.FromSeconds(2));
    }
}