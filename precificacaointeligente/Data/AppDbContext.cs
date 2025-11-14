using Microsoft.EntityFrameworkCore;
using precificacaointeligente.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; } = default!;
    public DbSet<LinhaProducao> LinhasProducao { get; set; } = default!;
    public DbSet<Produto> Produtos { get; set; } = default!;
    public DbSet<Producao> Producao { get; set; } = default!;
    public DbSet<Precificacao> Precificacao { get; set; } = default!;
    public DbSet<Venda> Vendas { get; set; } = default!;
    public DbSet<Relatorio> Relatorios { get; set; } = default!;
}
