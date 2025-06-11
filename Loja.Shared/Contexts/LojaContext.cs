using System.Text.Json;
using Loja.Shared.Models;

namespace Loja.Shared.Contexts;

public static class LojaContext
{
    public static List<Produto> Produtos { get; set; } = new();
    public static List<Cliente> Clientes { get; set; } = new();
    public static List<Vendedor> Vendedores { get; set; } = new();
    public static List<Venda> Vendas { get; set; } = new();

    public static void Inicializar()
    {
        Produtos.Recuperar();
        Clientes.Recuperar();
        Vendedores.Recuperar();
        Vendas.Recuperar();
    }

    public static void Finalizar()
    {
        Produtos.salvar();
        Clientes.salvar();
        Vendedores.salvar();
        Vendas.salvar();
    }

    public static void salvar<T>(this List<T> lista)
    {
        var tipo = typeof(T).Name;
        var pasta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        if (!Directory.Exists(Path.Combine(pasta, "Loja")))
        {
            Directory.CreateDirectory(Path.Combine(pasta, "Loja"));
        }

        var arquivo = Path.Combine(pasta, "Loja", $"{tipo}.json");
        var opcoes = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(lista, opcoes);
        File.WriteAllText(arquivo, json);

        Console.WriteLine($"lista de {tipo} salvos com sucesso em {arquivo}");
    }

    public static void Recuperar<T>(this List<T> lista)
    {
        var tipo = typeof(T).Name;
        var pasta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        if (!Directory.Exists(Path.Combine(pasta, "Loja")))
        {
            Directory.CreateDirectory(Path.Combine(pasta, "Loja"));
        }

        var arquivo = Path.Combine(pasta, "Loja", $"{tipo}.json");

        if (File.Exists(arquivo))
        {
            var json = File.ReadAllText(arquivo);
            var listarecuperada = JsonSerializer.Deserialize<List<T>>(json);
            if (listarecuperada != null)
            {
                lista.Clear();
                lista.AddRange(listarecuperada);
            }
        }

        Console.WriteLine($"lista de {tipo} recuperada com sucesso de {arquivo}");
    }
}
