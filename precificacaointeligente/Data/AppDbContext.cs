using Microsoft.EntityFrameworkCore;
using precificacaointeligente.Models;
using System;

namespace precificacaointeligente.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<LinhaProducao> LinhasProducao { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Producao> Producao { get; set; }
        public DbSet<Precificacao> Precificacao { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Relatorio> Relatorios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 🔑 Define PKs automaticamente (SQLite dá erro se não tiver)
            modelBuilder.Entity<Usuario>().HasKey(x => x.Id);
            modelBuilder.Entity<LinhaProducao>().HasKey(x => x.Id);
            modelBuilder.Entity<Produto>().HasKey(x => x.IdProduto);
            modelBuilder.Entity<Producao>().HasKey(x => x.IdProducao);
            modelBuilder.Entity<Precificacao>().HasKey(x => x.IdPrecificacao);
            modelBuilder.Entity<Venda>().HasKey(x => x.IdVenda);
            modelBuilder.Entity<Relatorio>().HasKey(x => x.IdRelatorio);

            // 🔐 Cria ADMIN se não existir
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    Nome = "Administrador",
                    Email = "admin@system.com",
                    Senha = "1234", // depois você troca por hash
                    Cargo = "Admin",
                    DataCadastro = DateTime.UtcNow
                }
            );
        }
    }
}
