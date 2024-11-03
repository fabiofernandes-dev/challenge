using FluentValidation;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.OutputCaching;
using Soma.Contracts.Requests;
using Soma.Contracts.Response;
using Soma.Api.Mapping;
using Soma.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Soma.Api.Endpoints.Adicao
{
    public static class AdicaoEndpoint
    {
        public const string Name = "Sum";

        public static IEndpointRouteBuilder MapSomarDoisNumeros(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/sum", async (
                    [AsParameters] SomaRequest request, IValidator<Models.Adicao> _adicaoValidator,
                    IValidator<SomaRequest> _requestValidator, CancellationToken token) =>
            {
                await _requestValidator.ValidateAndThrowAsync(request, token);

                var adicao = request.MapToAdicao();
                await _adicaoValidator.ValidateAndThrowAsync(adicao, token);

                var response = adicao.MapToResponse();
                return response;
            })
                .WithName(Name)
                .Produces<SomaResponse>(StatusCodes.Status200OK)
                .Produces<ValidationFailureResponse>(StatusCodes.Status400BadRequest);
            return app;
        }
    }
}
