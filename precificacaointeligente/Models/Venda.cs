using System;
using System.ComponentModel.DataAnnotations;

namespace precificacaointeligente.Models
{
    public class Venda
    {
        [Key]  // ← ESSENCIAL
        public int IdVenda { get; set; }

        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal? Lucro { get; set; }
        public DateTime DataVenda { get; set; }

        public Produto Produto { get; set; }
    }
}
