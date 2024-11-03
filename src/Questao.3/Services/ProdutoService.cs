using Questao._3.Models;
using Questao._3.Validators;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.OpenApi.Extensions;

namespace Questao._3.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly ProdutoValidator _validator;
        private readonly JsonSerializerOptions _jsonOptions;

        public ProdutoService(ProdutoValidator validator)
        {
            _validator = validator;
            _jsonOptions = ConfigurarOpcoesJson();
        }

        private JsonSerializerOptions ConfigurarOpcoesJson()
        {
            return new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                NumberHandling = JsonNumberHandling.AllowReadingFromString,
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task<IEnumerable<Produto>> ImportarProdutosAsync(string jsonContent)
        {
            try
            {
                var produtos = await Task.Run(() =>
                    JsonSerializer.Deserialize<List<Produto>>(jsonContent, _jsonOptions));

                if (produtos == null)
                    throw new ApplicationException("Falha ao deserializar produtos");

                var produtosValidos = new List<Produto>();
                var errosValidacao = new List<string>();

                foreach (var produto in produtos)
                {
                    var resultadoValidacao = _validator.Validate(produto);
                    if (resultadoValidacao.IsValid)
                    {
                        produtosValidos.Add(produto);
                    }
                    else
                    {
                        errosValidacao.AddRange(resultadoValidacao.Errors
                            .Select(e => $"Produto {produto.Descricao}: {e.ErrorMessage}"));
                    }
                }

                if (errosValidacao.Any())
                {
                    // Log ou trate os erros conforme necessário
                    Console.WriteLine("Erros de validação encontrados:");
                    foreach (var erro in errosValidacao)
                    {
                        Console.WriteLine(erro);
                    }
                }

                Console.WriteLine("\nProdutos válidos:");
                foreach (var produto in produtosValidos)
                {
                    Console.WriteLine($"Descrição: {produto.Descricao}");
                }

                return produtosValidos;
            }
            catch (JsonException ex)
            {
                throw new ApplicationException("Erro ao processar o JSON dos produtos", ex);
            }
        }

        public async Task<IEnumerable<Produto>> ObterProdutosMaisLucrativosAsync(IEnumerable<Produto> produtosValidos, int quantidade = 3)
        {
            var produtos = await Task.Run(() => produtosValidos
                .OrderByDescending(p => p.CalcularLucro())
                .Take(quantidade)
                .ToList());

            return produtos;
        }

        public async Task<IEnumerable<Produto>> ObterProdutosCriadosSegundoTrimestreAsync(IEnumerable<Produto> produtosValidos)
        {
            const int MES_INICIO_SEGUNDO_TRI = 4;
            const int MES_FIM_SEGUNDO_TRI = 6;

            return await Task.Run(() => produtosValidos
                .Where(p => p.DataCriacao.Year == DateTime.Now.Year && p.DataCriacao.Month >= MES_INICIO_SEGUNDO_TRI && p.DataCriacao.Month <= MES_FIM_SEGUNDO_TRI)
                .ToList());
        }

        public async Task<IEnumerable<Produto>> ObterProdutosOrdenadosPorTipo(IEnumerable<Produto> produtos)
        {
            return await Task.Run(()=> produtos
                .OrderBy(p => p.Tipo.GetDisplayName())
                .ToList());
        }
    }
}
