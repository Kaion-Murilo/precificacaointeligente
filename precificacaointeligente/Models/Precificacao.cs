namespace precificacaointeligente.Models
{
    public class Precificacao
    {
        public int IdPrecificacao { get; set; }
        public int IdProduto { get; set; }
        public decimal CustoTotal { get; set; }
        public decimal PrecoVenda { get; set; }
        public int UnidadesVendidas { get; set; }
        public decimal? PontoEquilibrioUnidades { get; set; }
        public decimal? LucroEstimado { get; set; }
        public DateTime DataCalculo { get; set; }

        public Produto Produto { get; set; }
    }
}
