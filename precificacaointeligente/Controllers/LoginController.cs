using Microsoft.AspNetCore.Mvc;
using precificacaointeligente.Data;
using System.Linq;

namespace precificacaointeligente.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Login/Index
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // POST: Login/Login
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.Nome == username && u.Senha == password);

            if (usuario != null)
            {
                // Login OK → redireciona
                return RedirectToAction("telainicial", "Home");
            }

            // Login falhou
            ViewData["ErrorMessage"] = "Usuário ou senha incorretos!";
            return View("Index");
        }
    }
}
