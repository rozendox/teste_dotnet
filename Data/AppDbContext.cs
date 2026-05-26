using Microsoft.EntityFrameworkCore;
using teste_dotnet.Models;

namespace teste_dotnet.Data;

/// Data/AppDbContext.cs

/// <summary>
/// Contexto principal de acesso ao banco de dados.
/// Responsável pelo mapeamento das entidades via Entity Framework.
/// </summary>

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Orcamento> Orcamentos { get; set; }
    public DbSet<OrcamentoItem> OrcamentoItens { get; set; }
}
