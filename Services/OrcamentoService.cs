using teste_dotnet.Data;
using teste_dotnet.DTOs;
using teste_dotnet.Models;

namespace teste_dotnet.Services;

/// <summary>
/// Serviço responsável pelas regras de negócio relacionadas ao orçamento.
/// </summary>
public class OrcamentoService
{   
    // injec do contexto de banco de dados para acesso para as entidades.
    private readonly AppDbContext _db;
    // O construtor recebe o contexto via injecao de dependencia, 
    // permitindo que o serviço acesse o banco de dados.
    public OrcamentoService(AppDbContext db)
    {   // privado 
        _db = db;
    }

    public async Task<(bool sucesso, string erro, CriarOrcamentoResponse dados)> CriarAsync(CriarOrcamentoRequest request)
    {
        // Validações  
        // Aqui podemos adicionar validações mais complexas, como verificar se o cliente e veículo existem no banco, etc.
        if (request.ClienteId <= 0)
            return (false, "ClienteId é obrigatório.", null);

        if (request.VeiculoId <= 0)
            return (false, "VeiculoId é obrigatório.", null);

        if (request.Itens == null || request.Itens.Count == 0)
            return (false, "O orçamento deve ter pelo menos 1 item.", null);

        foreach (var item in request.Itens)
        {
            if (string.IsNullOrWhiteSpace(item.Descricao))
                return (false, "Todos os itens devem ter uma descrição.", null);

            if (item.Quantidade <= 0)
                return (false, $"Item '{item.Descricao}': quantidade deve ser maior que zero.", null);

            if (item.ValorUnitario <= 0)
                return (false, $"Item '{item.Descricao}': valor unitário deve ser maior que zero.", null);
        }

        // Monta o orçamento 
        // Aqui criamos a entidade Orcamento e seus itens a partir dos dados recebidos na requisição.
        var orcamento = new Orcamento
        {
            ClienteId    = request.ClienteId,
            VeiculoId    = request.VeiculoId,
            Status       = "Aberto",
            DataCriacao  = DateTime.Now,
            Itens        = request.Itens.Select(i => new OrcamentoItem
            {
                Descricao      = i.Descricao,
                Quantidade     = i.Quantidade,
                ValorUnitario  = i.ValorUnitario,
                ValorTotal     = i.Quantidade * i.ValorUnitario
            }).ToList()
        };

        // Calcula o total somando os itens
        orcamento.ValorTotal = orcamento.Itens.Sum(i => i.ValorTotal);

        // Salva no banco 

        _db.Orcamentos.Add(orcamento);
        await _db.SaveChangesAsync();

        // Retorno

        var response = new CriarOrcamentoResponse
        {
            Id          = orcamento.Id,
            ClienteId   = orcamento.ClienteId,
            VeiculoId   = orcamento.VeiculoId,
            ValorTotal  = orcamento.ValorTotal,
            Status      = orcamento.Status,
            DataCriacao = orcamento.DataCriacao
        };

        return (true, null, response);
    }
}
