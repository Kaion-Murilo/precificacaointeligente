using Microsoft.AspNetCore.Mvc;
using precificacaointeligente.Models;

namespace precificacaointeligente.Controllers
{
    public class PrecificacaoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(PrecificacaoModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Resultado = model;
            }
            return View(model);
        }
    }
}
