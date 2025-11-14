using Microsoft.EntityFrameworkCore;
using precificacaointeligente.Models;

namespace precificacaointeligente.Data
{
    public static class DatabaseInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            // 🔥 Cria o banco + tabelas automaticamente (se não existir)
            context.Database.EnsureCreated();

            // 👇 Se não existir nenhum usuário, cria o admin padrão
            if (!context.Usuarios.Any())
            {
                context.Usuarios.Add(new Usuario
                {
                    Nome = "Administrador",
                    Email = "admin@admin.com",
                    Senha = "1234", // depois coloque hash real
                    Cargo = "Admin",
                    DataCadastro = DateTime.Now
                });

                context.SaveChanges();
            }
        }
    }
}
