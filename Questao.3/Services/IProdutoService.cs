using Questao._3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao._3.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> ObterProdutosOrdenadosPorTipo(IEnumerable<Produto> produtos);
        Task<IEnumerable<Produto>> ObterProdutosCriadosSegundoTrimestreAsync(IEnumerable<Produto> produtosValidos);
        Task<IEnumerable<Produto>> ObterProdutosMaisLucrativosAsync(IEnumerable<Produto> produtosValidos, int quantidade = 3);
        Task<IEnumerable<Produto>> ImportarProdutosAsync(string jsonContent);
    }
}
