namespace teste_dotnet.Models;

// Models/OrcamentoItem.cs

/// <summary>
/// Entidade de item do orçamento.
/// Representa produtos ou serviços vinculados ao orçamento.
/// </summary>
/// 

// Models/OrcamentoItem.cs
public class OrcamentoItem
{
    public int Id { get; set; }
    public int OrcamentoId { get; set; }
    public string Descricao { get; set; }
    public int Quantidade { get; set; }
    public decimal ValorUnitario { get; set; }
    public decimal ValorTotal { get; set; }
}
