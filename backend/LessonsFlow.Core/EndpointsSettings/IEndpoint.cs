namespace LessonsFlow.Core.EndpointsSettings;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}