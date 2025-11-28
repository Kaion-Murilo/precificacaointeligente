using Microsoft.AspNetCore.Mvc;
using precificacaointeligente.Models;

namespace precificacaointeligente.Controllers
{
    public class CramerController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            // retorna View com model vazio para inputs começarem vazios
            return View(new CramerModel());
        }

        // POST
        [HttpPost]
        public IActionResult Index(CramerModel model)
        {
            // 🔵 ALTERADO — calcular A1 e A2
            model.A1 = model.PriceA - model.VariableCostA;
            model.A2 = model.PriceB - model.VariableCostB;

            // 🔵 ALTERADO — C1 e C2
            model.C1 = model.FixedCostA;
            model.C2 = model.FixedCostB;

            // 🔵 ALTERADO — determinante principal
            model.D = (model.A1 * -1) - (-1 * model.A2);

            // 🔵 Se D = 0, não há solução única
            if (model.D == 0)
            {
                model.DeterminantZero = true;
                model.HasResult = true;     // Mostra mensagem na View
                return View(model);
            }

            // 🔵 ALTERADO — determinante Dx
            model.Dx = (model.C1 * -1) - (-1 * model.C2);

            // 🔵 ALTERADO — determinante Dl
            model.Dl = (model.A1 * model.C2) - (model.C1 * model.A2);

            // 🔵 ALTERADO — soluções
            model.Q = model.Dx / model.D;
            model.L = model.Dl / model.D;

            // Mostra o resultado
            model.HasResult = true;

            return View(model);
        }
    }
}
