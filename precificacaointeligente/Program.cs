using Microsoft.EntityFrameworkCore;
using precificacaointeligente.Data;
using precificacaointeligente.Models;

var builder = WebApplication.CreateBuilder(args);

// ---------------------------
// CONFIGURAÇÃO DO BANCO
// ---------------------------
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// ---------------------------
// CRIA O BANCO + TABELAS + ADMIN
// ---------------------------
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // Caminho do banco conforme appsettings.json
    var dbPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Teste.db");

    // 🔥 Só chama EnsureCreated SE o arquivo não existir
    if (!File.Exists(dbPath))
    {
        db.Database.EnsureCreated();

        // 👇 Cria admin somente na PRIMEIRA criação do banco
        db.Usuarios.Add(new Usuario
        {
            Nome = "Administrador",
            Email = "admin@admin.com",
            Senha = "1234",
            Cargo = "Admin",
            DataCadastro = DateTime.Now
        });

        db.SaveChanges();
    }
}

// ---------------------------
// PIPELINE DO ASP.NET
// ---------------------------
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Página inicial padrão
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
