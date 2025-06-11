using Loja.Shared.Contexts;
using Loja.Shared.Models;
using static System.Console;

namespace Loja.Console.Helpers;

internal static class MenuHelpers
{
    public static void Criarlinha()
    {
        ForegroundColor = ConsoleColor.DarkGray;
        WriteLine("=========================================================");
    }

    public static void CriarCabecalho(string titulo)
    {
        ForegroundColor = ConsoleColor.White;
        Clear();
        Criarlinha();
        ForegroundColor = ConsoleColor.Blue;
        WriteLine($" {titulo.ToUpper()}");
        Criarlinha();
    }

    public static void MenuPrincipal()
    {
        CriarCabecalho("Loja Sapiens");
        WriteLine(" [1] - Vendas");
        WriteLine(" [2] - Clientes");
        WriteLine(" [3] - Vendedores");
        WriteLine(" [4] - Produtos");
        WriteLine("\n [9] - Sair");
        Criarlinha();
        Write(" Escolha uma opção: ");
        var opcao = ReadLine();
        switch (opcao)
        {
            case "1": MenuVendas(); break;
            case "2": MenuCliente(); break;
            case "3": MenuVendedores(); break;
            case "4": MenuProdutos(); break;
            case "9":
                LojaContext.Finalizar();
                CriarCabecalho("Obrigado por usar nosso sistema");
                ReadKey();
                Environment.Exit(0); break;
        }
        MenuPrincipal();
    }
    public static void MenuProdutos()
    {
        CriarCabecalho("Loja Sapiens - Produto");
        WriteLine(" [1] - Cadastrar");
        WriteLine(" [2] - Listar");
        WriteLine(" [3] - Editar");
        WriteLine(" [4] - Excluir");
        WriteLine("\n [9] - Voltar ao Menu Principal");
        Criarlinha();
        Write(" Escolha uma opção: ");
        var opcao = ReadLine();
        switch (opcao)
        {
            case "1": ProdutoHelper.cadastrarProduto(); break;
            case "2": ProdutoHelper.listarProdutos(); break;
            case "3": ProdutoHelper.editarProduto(); break;
            case "4": ProdutoHelper.excluirProduto(); break;
            case "9": MenuPrincipal(); break;
        }
        MenuPrincipal();
    }
    public static void MenuCliente()
    {
        CriarCabecalho("Loja Sapiens - Cliente");
        WriteLine(" [1] - Cadastrar");
        WriteLine(" [2] - Listar");
        WriteLine(" [3] - Editar");
        WriteLine(" [4] - Excluir");
        WriteLine("\n [9] - Voltar ao Menu Principal");
        Criarlinha();
        Write(" Escolha uma opção: ");
        var opcao = ReadLine();
        switch (opcao)
        {
            case "1": ClinteHelper.cadastrarCliente(); break;
            case "2": ClinteHelper.listarCliente(); break;
            case "3": ClinteHelper.editarCliente(); break;
            case "4": ClinteHelper.excluirCliente(); break;
            case "9": MenuPrincipal(); break;
        }
        MenuPrincipal();
    }
    public static void MenuVendas()
    {
        CriarCabecalho("Loja Sapiens - Vendas");
        WriteLine(" [1] - Cadastrar");
        WriteLine(" [2] - Listar");
        WriteLine(" [3] - Editar");
        WriteLine(" [4] - Excluir");
        WriteLine("\n [9] - Voltar ao Menu Principal");
        Criarlinha();
        Write(" Escolha uma opção: ");
        var opcao = ReadLine();
        switch (opcao)
        {
            case "1": VendasHelper.cadastrarVendas(); break;
            case "2": VendasHelper.listarVendas(); break;
            case "3": VendasHelper.editarVendas(); break;
            case "4": VendasHelper.excluirVendas(); break;
            case "9": MenuPrincipal(); break;
        }
        MenuPrincipal();
    }
    public static void MenuVendedores()
    {
        CriarCabecalho("Loja Sapiens - Vendedores");
        WriteLine(" [1] - Cadastrar");
        WriteLine(" [2] - Listar");
        WriteLine(" [3] - Editar");
        WriteLine(" [4] - Excluir");
        WriteLine("\n [9] - Voltar ao Menu Principal");
        Criarlinha();
        Write(" Escolha uma opção: ");
        var opcao = ReadLine();
        switch (opcao)
        {
            case "1": VendedorHelper.cadastrarVendedor(); break;
            case "2": VendedorHelper.listarVendedor(); break;
            case "3": VendedorHelper.editarVendedor(); break;
            case "4": VendedorHelper.excluirVendedor(); break;
            case "9": MenuPrincipal(); break;
        }
        MenuPrincipal();
    }
}
