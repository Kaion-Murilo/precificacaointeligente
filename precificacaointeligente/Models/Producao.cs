using System;
using System.ComponentModel.DataAnnotations;

namespace precificacaointeligente.Models
{
    public class Producao
    {
        [Key]  // ← OBRIGATÓRIO
        public int IdProducao { get; set; }

        public int IdProduto { get; set; }
        public int IdLinha { get; set; }

        public int Quantidade { get; set; }
        public decimal? TempoGastoHoras { get; set; }
        public decimal? CustoTotal { get; set; }

        public DateTime DataProducao { get; set; } = DateTime.Now;

        public Produto Produto { get; set; }
        public LinhaProducao Linha { get; set; }
    }
}
