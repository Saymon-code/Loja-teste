namespace Loja.Shared.Models;

public class Venda
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public int VendedorId { get; set; }
    public DateTime Data { get; set; }
    public decimal ValorTotal { get; set; }

    public override string ToString()
    {
        return $"Venda {Id.ToString("D3")} - Cliente: {ClienteId} - Vendedor: {VendedorId} - Data: {Data:dd/MM/yyyy} - Total: {ValorTotal:C}";
    }
}
