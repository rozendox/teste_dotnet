namespace teste_dotnet.DTOs;


// DTOs/CriarOrcamentoResponse.cs

/// <summary>
/// DTO utilizado para retornar os dados do orçamento criado.
/// </summary>
///

public class CriarOrcamentoResponse
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public int VeiculoId { get; set; }
    public decimal ValorTotal { get; set; }
    public string Status { get; set; }
    public DateTime DataCriacao { get; set; }
}
