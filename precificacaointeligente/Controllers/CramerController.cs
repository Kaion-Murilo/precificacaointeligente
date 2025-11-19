using Microsoft.AspNetCore.Mvc;
using precificacaointeligente.Models;
using System;

namespace precificacaointeligente.Controllers
{
    public class CramerController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new ProductComparisonModel());
        }

        [HttpPost]
        public IActionResult Index(ProductComparisonModel model)
        {
            // validação básica
            if (model == null)
            {
                ModelState.AddModelError("", "Dados inválidos.");
                return View(new ProductComparisonModel());
            }

            // Calcula coeficientes A1 e A2 (margens unitárias)
            model.A1 = model.PriceA - model.VariableCostA; // coeficiente de Q na eq1
            model.A2 = model.PriceB - model.VariableCostB; // coeficiente de Q na eq2

            // termos independentes (custos fixos)
            model.C1 = model.FixedCostA;
            model.C2 = model.FixedCostB;

            // Montamos o sistema da forma:
            // (A1)·Q + (-1)·L = C1
            // (A2)·Q + (-1)·L = C2
            // matriz dos coeficientes:
            // | A1   -1 |
            // | A2   -1 |

            // Determinante principal D = a·d - b·c
            // aqui a = A1, b = -1, c = A2, d = -1
            model.D = (model.A1 * -1.0) - (-1.0 * model.A2);

            // se D == 0 => sistema sem solução única (dependente ou infinito)
            if (Math.Abs(model.D) < 1e-12) // tolerância numérica
            {
                ViewBag.Error = "Não é possível aplicar a Regra de Cramer: determinante D = 0 (sistema sem solução única). Tente valores diferentes.";
                // limpamos quaisquer resultados antigos
                model.QuantityBreakEven = null;
                model.ProfitAtBreakEven = null;
                model.Dx = 0;
                model.Dl = 0;
                return View(model);
            }

            // Dx (troca coluna de Q pelos termos independentes C1, C2)
            // matriz Dx:
            // | C1  -1 |
            // | C2  -1 |
            model.Dx = (model.C1 * -1.0) - (-1.0 * model.C2);

            // Dl (troca coluna de L pelos termos independentes)
            // matriz Dl:
            // | A1  C1 |
            // | A2  C2 |
            model.Dl = (model.A1 * model.C2) - (model.C1 * model.A2);

            // Soluções de Cramer
            double q = model.Dx / model.D;
            double l = model.Dl / model.D;

            // Guarda resultados arredondados para exibição
            model.QuantityBreakEven = Math.Round(q, 4); // quatro casas para ver precisão
            model.ProfitAtBreakEven = Math.Round(l, 4);

            return View(model);
        }
    }
}
