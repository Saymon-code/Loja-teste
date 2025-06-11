namespace Loja.Shared.Models;

public class Vendedor
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? CPF { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }

    public override string ToString()
    {
        return $"V{Id.ToString("D3")} {Nome} - CPF{CPF}";
    }
}
