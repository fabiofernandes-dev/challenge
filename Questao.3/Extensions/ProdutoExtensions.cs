using Microsoft.OpenApi.Extensions;
using Questao._3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao._3.Extensions
{
    public static class ProdutoExtensions
    {        
        public static void ImprimirProdutosMaisLucrativos(this IEnumerable<Produto> produtos)
        {
            if (produtos is null)
            {
                Console.WriteLine("\nLista de produtos vazia");
                return;
            }

            Console.WriteLine("\nProdutos mais lucrativos:");
            foreach (var produto in produtos)
            {
                Console.WriteLine(
                    $"Descrição: {produto.Descricao}, " +
                    $"Lucro: {produto.CalcularLucro():C2}");
            }
        }

        public static void ImprimirProdutosCriadosNoTrimestre(this IEnumerable<Produto> produtos)
        {
            if (produtos is null)
            {
                Console.WriteLine("\nLista de produtos vazia");
                return;
            }

            Console.WriteLine($"\nProdutos criados no segundo trimestre de {DateTime.Now.Year}:");
            foreach (var produto in produtos)
            {
                Console.WriteLine($"Descrição: {produto.Descricao}, Data de Criação: {produto.DataCriacao:dd/MM/yyyy}");
            }
        }

        public static void ImprimirProdutosOrdenadosPorTipo(this IEnumerable<Produto> produtos)
        {
            Console.WriteLine("\nProdutos ordenados por tipo:");
            foreach (var produto in produtos)
            {
                Console.WriteLine($"Tipo: {produto.Tipo.GetDisplayName()}, Descrição: {produto.Descricao}");
            }
        }
    }
}
