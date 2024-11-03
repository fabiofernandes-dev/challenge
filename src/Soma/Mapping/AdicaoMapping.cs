using Soma.Contracts.Requests;
using Soma.Contracts.Response;
using Soma.Api.Models;
using Soma.Api.Extensions;

namespace Soma.Api.Mapping
{
    public static class AdicaoMapping
    {
        public static Adicao MapToAdicao(this SomaRequest request)
        {
            return new Adicao
            {
                PrimeiraParcela = request?.A?.ToDouble() ?? 0,
                SegundaParcela = request?.B?.ToDouble() ?? 0,
            };
        }

        public static SomaResponse MapToResponse(this Adicao adicao)
        {

            return new SomaResponse
            {
                Result = adicao.Calcular()
            };
        }
    }
}
