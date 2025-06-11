using Loja.Shared.Contexts;
using Loja.Shared.Models;
using static System.Console;
namespace Loja.Console.Helpers;

internal static class ProdutoHelper
{
    public static void cadastrarProduto()
    {
        var Produto = new Produto();
        MenuHelpers.CriarCabecalho("Cadastrar Produto");
        Write(" Codigo: ");
        Produto.Id = Convert.ToInt32(ReadLine());
        Write(" Nome: ");
        Produto.Nome = ReadLine();
        Write(" Valor: ");
        Produto.Valor = Convert.ToDecimal(ReadLine());
        MenuHelpers.Criarlinha();
        LojaContext.Produtos.Add(Produto);
        Write(" [Enter] para continuar...");
        ReadLine();
        MenuHelpers.MenuProdutos();
    }
    public static void listarProdutos()
    {
        MenuHelpers.CriarCabecalho("Listar Produtos");
        if (LojaContext.Produtos.Count == 0)
        {
            WriteLine(" Nenhum produto cadastrado.");
        }
        else
        {
            foreach (var produto in LojaContext.Produtos)
            {
                WriteLine($" Id: {produto.Id} - Nome: {produto.Nome} - Valor: {produto.Valor:C}");
            }
        }
        MenuHelpers.Criarlinha();
        Write(" [Enter] para continuar...");
        ReadLine();
        MenuHelpers.MenuProdutos();
    }
    public static void editarProduto()
    {
    MenuHelpers.CriarCabecalho("EDITAR PRODUTO");
        Write(" INFORME O CODIGO DO PRODUTO: ");
    int codigo = Convert.ToInt32(ReadLine());
    var produto = LojaContext.Produtos.Find(p => p.Id == codigo);

        if (produto == null)
        {
            WriteLine(" Produto não encontrado.");
        }
        else
        {
           ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"\n Produto encontrado: {produto.Nome} - Valor: {produto.Valor:C}");
            ForegroundColor = ConsoleColor.White;
            Write(" Novo Nome ");
            var Nome = ReadLine();
            if (!string.IsNullOrEmpty(Nome))
                produto.Nome = Nome;

            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"\n Valor Atual: {produto.Valor}");
            ForegroundColor = ConsoleColor.White;
            Write(" Novo Valor: ");
            var valor = ReadLine();
            if (!string.IsNullOrEmpty(valor))
                produto.Valor = Convert.ToDecimal(valor);

            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"\n Quantidade atual: {produto.Quantidade}");
            ForegroundColor = ConsoleColor.White;
            Write(" Nova Quantidade: ");
            var quantidade = ReadLine();
            if (!string.IsNullOrEmpty(quantidade))
                produto.Quantidade = Convert.ToInt32(quantidade);

            WriteLine("\n Produto atualizado com sucesso!");

        }
        MenuHelpers.Criarlinha();
        Write(" [Enter] para continuar...");
        ReadLine();
        MenuHelpers.MenuProdutos();
    }
    public static void excluirProduto()
    {
        MenuHelpers.CriarCabecalho("EXCLUIR PRODUTO");
        Write(" INFORME O CODIGO DO PRODUTO: ");
        int codigo = Convert.ToInt32(ReadLine());
        var produto = LojaContext.Produtos.Find(p => p.Id == codigo);

        if (produto == null)
        {
            WriteLine(" Produto não encontrado.");
        }
        else
        {
            WriteLine(" \n deseja realmente excluir o produto? (S/N)");
            WriteLine(" "  + produto.Nome);
            Write(" [S] / [N]  ");
            var opcao = ReadLine()?.ToUpper();
            if (opcao == "S")
            {
                LojaContext.Produtos.Remove(produto);
                WriteLine(" Produto excluído com sucesso!");
            }
            MenuHelpers.Criarlinha();
            Write(" [Enter] para continuar...");
            ReadLine();
            MenuHelpers.MenuProdutos();
        }
    }
}
