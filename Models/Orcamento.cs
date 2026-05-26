// Models/Orcamento.cs

/// <summary>
/// Entidade principal de orçamento.
/// Representa o cabeçalho do orçamento no banco de dados.
/// </summary>

public class Orcamento
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public int VeiculoId { get; set; }
    public string Status { get; set; }
    public decimal ValorTotal { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataFinalizacao { get; set; }

    public List<OrcamentoItem> Itens { get; set; } = new();
}
