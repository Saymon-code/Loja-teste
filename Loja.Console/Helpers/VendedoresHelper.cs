using Loja.Shared.Contexts;
using Loja.Shared.Models;
using static System.Console;

namespace Loja.Console.Helpers;

internal static class VendedorHelper
{
    public static void cadastrarVendedor()
    {
        var vendedor = new Vendedor();
        MenuHelpers.CriarCabecalho("Cadastrar Vendedor");
        Write(" Código: ");
        vendedor.Id = Convert.ToInt32(ReadLine());
        Write(" Nome: ");
        vendedor.Nome = ReadLine();
        Write(" Cadastro de Pessoas Físicas - (CPF): ");
        vendedor.CPF = ReadLine();
        Write(" Telefone: ");
        vendedor.Telefone = ReadLine();
        Write(" Email: ");
        vendedor.Email = ReadLine();
        MenuHelpers.Criarlinha();
        LojaContext.Vendedores.Add(vendedor);
        Write(" [Enter] para continuar...");
        ReadLine();
        MenuHelpers.MenuVendedores();
    }

    public static void listarVendedor()
    {
        MenuHelpers.CriarCabecalho("Listar Vendedores");
        if (LojaContext.Vendedores.Count == 0)
        {
            WriteLine(" Nenhum Vendedor cadastrado.");
        }
        else
        {
            foreach (var vendedor in LojaContext.Vendedores)
            {
                WriteLine($" Id: {vendedor.Id} - Nome: {vendedor.Nome} - CPF: {vendedor.CPF} - Telefone: {vendedor.Telefone} - Email: {vendedor.Email}");
            }
        }
        MenuHelpers.Criarlinha();
        Write(" [Enter] para continuar...");
        ReadLine();
        MenuHelpers.MenuVendedores();
    }

    public static void editarVendedor()
    {
        MenuHelpers.CriarCabecalho("EDITAR VENDEDOR");
        Write(" INFORME O CODIGO DO VENDEDOR: ");
        int codigo = Convert.ToInt32(ReadLine());
        var vendedor = LojaContext.Vendedores.Find(v => v.Id == codigo);

        if (vendedor == null)
        {
            WriteLine(" Vendedor não encontrado.");
        }
        else
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"\n Vendedor encontrado: {vendedor.Nome} - CPF: {vendedor.CPF}");
            ForegroundColor = ConsoleColor.White;

            Write(" Novo Nome: ");
            var nome = ReadLine();
            if (!string.IsNullOrEmpty(nome))
                vendedor.Nome = nome;

            Write(" Novo CPF: ");
            var cpf = ReadLine();
            if (!string.IsNullOrEmpty(cpf))
                vendedor.CPF = cpf;

            Write(" Novo Telefone: ");
            var telefone = ReadLine();
            if (!string.IsNullOrEmpty(telefone))
                vendedor.Telefone = telefone;

            Write(" Novo Email: ");
            var email = ReadLine();
            if (!string.IsNullOrEmpty(email))
                vendedor.Email = email;

            WriteLine("\n Vendedor atualizado com sucesso!");
        }

        MenuHelpers.Criarlinha();
        Write(" [Enter] para continuar...");
        ReadLine();
        MenuHelpers.MenuVendedores();
    }

    public static void excluirVendedor()
    {
        MenuHelpers.CriarCabecalho("EXCLUIR VENDEDOR");
        Write(" INFORME O CODIGO DO VENDEDOR: ");
        int codigo = Convert.ToInt32(ReadLine());
        var vendedor = LojaContext.Vendedores.Find(v => v.Id == codigo);

        if (vendedor == null)
        {
            WriteLine(" Vendedor não encontrado.");
        }
        else
        {
            WriteLine("\n Deseja realmente excluir o vendedor? (S/N)");
            WriteLine(" " + vendedor.Nome);
            Write(" [S] / [N]  ");
            var opcao = ReadLine()?.ToUpper();
            if (opcao == "S")
            {
                LojaContext.Vendedores.Remove(vendedor);
                WriteLine(" Vendedor excluído com sucesso!");
            }

            MenuHelpers.Criarlinha();
            Write(" [Enter] para continuar...");
            ReadLine();
            MenuHelpers.MenuVendedores();
        }
    }
}
