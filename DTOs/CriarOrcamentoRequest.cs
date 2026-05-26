namespace teste_dotnet.DTOs;

// DTOs/CriarOrcamentoRequest.cs

/// <summary>
/// DTO utilizado para receber os dados de criação de orçamento.
/// </summary>


public class CriarOrcamentoRequest
{
    public int ClienteId { get; set; }
    public int VeiculoId { get; set; }
    public List<OrcamentoItemRequest> Itens { get; set; } = new();
}

public class OrcamentoItemRequest
{
    public string Descricao { get; set; }
    public int Quantidade { get; set; }
    public decimal ValorUnitario { get; set; }
}
