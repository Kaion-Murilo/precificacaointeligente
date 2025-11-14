using System;
using System.ComponentModel.DataAnnotations;

namespace precificacaointeligente.Models
{
    public class Precificacao
    {
        [Key]  // ← OBRIGATÓRIO PARA O EF
        public int IdPrecificacao { get; set; }

        public int IdProduto { get; set; }
        public Produto Produto { get; set; }

        // CAMPOS DO SEU FORMULÁRIO
        public decimal CustoFixo { get; set; }
        public decimal CustoVariavel { get; set; }
        public decimal PrecoVenda { get; set; }
        public int Quantidade { get; set; }
        public decimal MargemLucro { get; set; }

        // CAMPOS DE RESULTADO
        public decimal CustoTotal { get; set; }
        public decimal? PontoEquilibrioUnidades { get; set; }
        public decimal? LucroEstimado { get; set; }

        public DateTime DataCalculo { get; set; } = DateTime.Now;
    }
}
