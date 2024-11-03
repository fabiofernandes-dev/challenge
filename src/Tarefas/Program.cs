using System;
using System.Diagnostics;
using System.Text.Json;
using Tarefas;

class Program
{
    static Random _random = new Random();
    static async Task Main(string[] args)
    {
        Console.WriteLine("Processamento de tarefas...");
        var _random = new Random();
        string jsonTarefas = @"[
            { ""id"": 1, ""nome"": ""Tarefa A"" },
            { ""id"": 2, ""nome"": ""Tarefa B"" },
            { ""id"": 3, ""nome"": ""Tarefa C"" },
            { ""id"": 4, ""nome"": ""Tarefa D"" },
            { ""id"": 5, ""nome"": ""Tarefa E"" },
            { ""id"": 6, ""nome"": ""Tarefa F"" },
            { ""id"": 7, ""nome"": ""Tarefa G"" },
            { ""id"": 8, ""nome"": ""Tarefa H"" },
            { ""id"": 9, ""nome"": ""Tarefa I"" },
            { ""id"": 10, ""nome"": ""Tarefa J"" }
        ]";

        var tarefasJson = JsonSerializer.Deserialize<List<Tarefa>>(jsonTarefas, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        var tarefas = new List<Task>();
        foreach (var tarefa in tarefasJson)
        {
            tarefas.Add(ProcessarTarefaAsync(tarefa));
        }
        
        await Task.WhenAll(tarefas);
        Console.WriteLine("Todas as tarefas foram concluídas.");
        Console.ReadKey();
    }

    static async Task ProcessarTarefaAsync(Tarefa tarefa)
    {
        var timer = new Stopwatch();
        timer.Start();
        int delay = _random.Next(1000, 5001); 
        await Task.Delay(delay);

        timer.Stop();
        Console.WriteLine($"{tarefa.Nome} (ID: {tarefa.Id}) concluída em {timer.ElapsedMilliseconds / 1000.0:F1} segundos.");
    }
}
