namespace Loja.Shared.Models;

public class Cliente

{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? CPF { get; set; }
    public String? Celular { get; set; }
    public String? Email { get; set; }

    public override string ToString()
    {
        return $"C{Id.ToString("D3")} {Nome} - CPF{CPF}";
    }
}
