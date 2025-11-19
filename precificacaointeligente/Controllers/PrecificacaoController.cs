using Microsoft.AspNetCore.Mvc;
using precificacaointeligente.Models;

using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Metadata;
using System.Xml.Linq;

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
                // Cálculos básicos
                double lucro = (model.PrecoVenda - model.CustoVariavel) * model.Quantidade - model.CustoFixo;
                double pontoEquilibrio = model.CustoFixo / (model.PrecoVenda - model.CustoVariavel);
                double precoIdeal = model.CustoVariavel / (1 - (model.MargemLucro / 100));

                ViewBag.Resultado = new
                {
                    Lucro = lucro,
                    PontoEquilibrio = pontoEquilibrio,
                    PrecoIdeal = precoIdeal,
                    CustoFixo = model.CustoFixo,
                    CustoVariavel = model.CustoVariavel,
                    PrecoVenda = model.PrecoVenda,
                    Quantidade = model.Quantidade,
                    MargemLucro = model.MargemLucro
                };
            }

            return View(model);
        }

    }
}
