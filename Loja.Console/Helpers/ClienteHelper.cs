using Loja.Shared.Contexts;
using Loja.Shared.Models;
using static System.Console;
namespace Loja.Console.Helpers;

internal static class ClinteHelper
{
    public static void cadastrarCliente()
    {
        var cliente = new Cliente();
        MenuHelpers.CriarCabecalho("Cadastrar Cliente");
        Write(" Código: ");
        cliente.Id = Convert.ToInt32(ReadLine());
        Write(" Nome: ");
        cliente.Nome = ReadLine();
        Write(" Cadastro de Pessoas Físicas - (CPF): ");
        cliente.CPF = ReadLine();
        Write(" Celular: ");
        cliente.Celular = ReadLine();
        Write(" Email: ");
        cliente.Email = ReadLine();
        MenuHelpers.Criarlinha();
        LojaContext.Clientes.Add(cliente);
        Write(" [Enter] para continuar...");
        ReadLine();
        MenuHelpers.MenuCliente();
    }
    public static void listarCliente()
    {
        MenuHelpers.CriarCabecalho("Listar Clientes");
        if (LojaContext.Clientes.Count == 0)
        {
            WriteLine(" Nenhum Cliente cadastrado.");
        }
        else
        {
            foreach (var cliente in LojaContext.Clientes)
            {
                WriteLine($" Id: {cliente.Id} - Nome: {cliente.Nome} - CPF: {cliente.CPF} - Celular: {cliente.Celular} - Email: {cliente.Email}");
            }
        }
        MenuHelpers.Criarlinha();
        Write(" [Enter] para continuar...");
        ReadLine();
        MenuHelpers.MenuCliente();

    }
    public static void editarCliente()
    {
        MenuHelpers.CriarCabecalho("EDITAR CLIENTE");
        Write(" INFORME O CODIGO DO CLIENTE: ");
        int codigo = Convert.ToInt32(ReadLine());
        var cliente = LojaContext.Clientes.Find(c => c.Id == codigo);

        if (cliente == null)
        {
            WriteLine(" Cliente não encontrado.");
        }
        else
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"\n Cliente encontrado: {cliente.Nome} - CPF: {cliente.CPF}");
            ForegroundColor = ConsoleColor.White;

            Write(" Novo Nome: ");
            var nome = ReadLine();
            if (!string.IsNullOrEmpty(nome))
                cliente.Nome = nome;

            Write(" Novo CPF: ");
            var cpf = ReadLine();
            if (!string.IsNullOrEmpty(cpf))
                cliente.CPF = cpf;

            Write(" Novo Celular: ");
            var celular = ReadLine();
            if (!string.IsNullOrEmpty(celular))
                cliente.Celular = celular;

            Write(" Novo Email: ");
            var email = ReadLine();
            if (!string.IsNullOrEmpty(email))
                cliente.Email = email;

            WriteLine("\n Cliente atualizado com sucesso!");
        }

        MenuHelpers.Criarlinha();
        Write(" [Enter] para continuar...");
        ReadLine();
        MenuHelpers.MenuCliente();

    }
    public static void excluirCliente()
    {
        MenuHelpers.CriarCabecalho("EXCLUIR CLIENTE");
        Write(" INFORME O CODIGO DO CLIENTE: ");
        int codigo = Convert.ToInt32(ReadLine());
        var cliente = LojaContext.Clientes.Find(c => c.Id == codigo);

        if (cliente == null)
        {
            WriteLine(" Cliente não encontrado.");
        }
        else
        {
            WriteLine("\n Deseja realmente excluir o cliente? (S/N)");
            WriteLine(" " + cliente.Nome);
            Write(" [S] / [N]  ");
            var opcao = ReadLine()?.ToUpper();
            if (opcao == "S")
            {
                LojaContext.Clientes.Remove(cliente);
                WriteLine(" Cliente excluído com sucesso!");
            }

            MenuHelpers.Criarlinha();
            Write(" [Enter] para continuar...");
            ReadLine();
            MenuHelpers.MenuCliente();
        }
    }
}
