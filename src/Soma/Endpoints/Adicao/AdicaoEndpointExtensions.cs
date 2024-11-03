namespace Soma.Api.Endpoints.Adicao
{
    public static class AdicaoEndpointExtensions
    {
        public static IEndpointRouteBuilder MapAdicaoEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapSomarDoisNumeros();
            return app;
        }
    }
}
