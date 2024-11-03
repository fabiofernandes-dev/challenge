
using Soma.Api.Endpoints.Adicao;

namespace Soma.Api.Endpoints;

public static class EndpointsExtensions
{
    public static IEndpointRouteBuilder MapApiEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapAdicaoEndpoints();       
        return app;
    }
}
