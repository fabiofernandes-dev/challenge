using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Questao._3.Extensions;
using Questao._3.Services;
using Questao._3.Validators;

public class Program
{
    private static async Task Main(string[] args)
    {
        try
        {
            await Executar();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro na execução do programa: {ex.Message}");
        }
    }

    private static async Task Executar()
    {
        var serviceProvider = ConfigurarServicos();

        var produtoService = serviceProvider.GetRequiredService<IProdutoService>();

        var jsonContent = await File.ReadAllTextAsync("produtos.json");
        var produtos = await produtoService.ImportarProdutosAsync(jsonContent);

        var produtosTrimestre = await produtoService.ObterProdutosCriadosSegundoTrimestreAsync(produtos);
        produtosTrimestre.ImprimirProdutosCriadosNoTrimestre();

        var produtosOrdenados = await produtoService.ObterProdutosOrdenadosPorTipo(produtos);
        produtosOrdenados.ImprimirProdutosOrdenadosPorTipo();

        var produtosMaisLucrativos = await produtoService
        .ObterProdutosMaisLucrativosAsync(produtos);
        produtosMaisLucrativos.ImprimirProdutosMaisLucrativos();
        Console.ReadKey();
    }

    private static IServiceProvider ConfigurarServicos()
    {
        var services = new ServiceCollection();

        services.AddScoped<ProdutoValidator>();
        services.AddScoped<IProdutoService, ProdutoService>();

        return services.BuildServiceProvider();
    }    
}
