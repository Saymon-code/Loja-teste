using Loja.Shared.Contexts;
using Loja.Shared.Models;
using static System.Console;

namespace Loja.Console.Helpers;

internal static class VendasHelper
{
    public static void cadastrarVendas()
    {
        var venda = new Venda();
        MenuHelpers.CriarCabecalho("Cadastrar Venda");

        Write(" Código da Venda: ");
        venda.Id = Convert.ToInt32(ReadLine());

        Write(" Código do Cliente: ");
        venda.ClienteId = Convert.ToInt32(ReadLine());

        Write(" Código do Vendedor: ");
        venda.VendedorId = Convert.ToInt32(ReadLine());

        Write(" Data da Venda (dd/MM/yyyy): ");
        venda.Data = DateTime.Parse(ReadLine()!);

        Write(" Valor Total: ");
        venda.ValorTotal = Convert.ToDecimal(ReadLine());

        MenuHelpers.Criarlinha();
        LojaContext.Vendas.Add(venda);
        Write(" [Enter] para continuar...");
        ReadLine();
        MenuHelpers.MenuVendas();
    }

    public static void listarVendas()
    {
        MenuHelpers.CriarCabecalho("Listar Vendas");

        if (LojaContext.Vendas.Count == 0)
        {
            WriteLine(" Nenhuma Venda cadastrada.");
        }
        else
        {
            foreach (var venda in LojaContext.Vendas)
            {
                WriteLine($" Id: {venda.Id} - Cliente: {venda.ClienteId} - Vendedor: {venda.VendedorId} - Data: {venda.Data:dd/MM/yyyy} - Valor: {venda.ValorTotal:C}");
            }
        }

        MenuHelpers.Criarlinha();
        Write(" [Enter] para continuar...");
        ReadLine();
        MenuHelpers.MenuVendas();
    }

    public static void editarVendas()
    {
        MenuHelpers.CriarCabecalho("EDITAR VENDA");
        Write(" INFORME O CODIGO DA VENDA: ");
        int codigo = Convert.ToInt32(ReadLine());
        var venda = LojaContext.Vendas.Find(v => v.Id == codigo);

        if (venda == null)
        {
            WriteLine(" Venda não encontrada.");
        }
        else
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"\n Venda encontrada - Data: {venda.Data:dd/MM/yyyy} - Valor: {venda.ValorTotal:C}");
            ForegroundColor = ConsoleColor.White;

            Write(" Novo Código do Cliente: ");
            var clienteId = ReadLine();
            if (!string.IsNullOrEmpty(clienteId))
                venda.ClienteId = Convert.ToInt32(clienteId);

            Write(" Novo Código do Vendedor: ");
            var vendedorId = ReadLine();
            if (!string.IsNullOrEmpty(vendedorId))
                venda.VendedorId = Convert.ToInt32(vendedorId);

            Write(" Nova Data (dd/MM/yyyy): ");
            var data = ReadLine();
            if (!string.IsNullOrEmpty(data))
                venda.Data = DateTime.Parse(data);

            Write(" Novo Valor Total: ");
            var valor = ReadLine();
            if (!string.IsNullOrEmpty(valor))
                venda.ValorTotal = Convert.ToDecimal(valor);

            WriteLine("\n Venda atualizada com sucesso!");
        }

        MenuHelpers.Criarlinha();
        Write(" [Enter] para continuar...");
        ReadLine();
        MenuHelpers.MenuVendas();
    }

    public static void excluirVendas()
    {
        MenuHelpers.CriarCabecalho("EXCLUIR VENDA");
        Write(" INFORME O CODIGO DA VENDA: ");
        int codigo = Convert.ToInt32(ReadLine());
        var venda = LojaContext.Vendas.Find(v => v.Id == codigo);

        if (venda == null)
        {
            WriteLine(" Venda não encontrada.");
        }
        else
        {
            WriteLine("\n Deseja realmente excluir a venda? (S/N)");
            WriteLine($" Venda {venda.Id} - Cliente: {venda.ClienteId} - Valor: {venda.ValorTotal:C}");
            Write(" [S] / [N]  ");
            var opcao = ReadLine()?.ToUpper();
            if (opcao == "S")
            {
                LojaContext.Vendas.Remove(venda);
                WriteLine(" Venda excluída com sucesso!");
            }

            MenuHelpers.Criarlinha();
            Write(" [Enter] para continuar...");
            ReadLine();
            MenuHelpers.MenuVendas();
        }
    }
}
