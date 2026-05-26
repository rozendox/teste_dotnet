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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Orcamento>(entity =>
        {
            entity.Property(e => e.ValorTotal).HasPrecision(18, 2);
        });

        modelBuilder.Entity<OrcamentoItem>(entity =>
        {
            entity.Property(e => e.ValorUnitario).HasPrecision(18, 2);
            entity.Property(e => e.ValorTotal).HasPrecision(18, 2);
        });
    }
}
