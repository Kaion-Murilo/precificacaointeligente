namespace precificacaointeligente.Models
{
    public class PrecificacaoModel
    {
        public double CustoFixo { get; set; }
        public double CustoVariavel { get; set; }
        public double PrecoVenda { get; set; }
        public double Quantidade { get; set; }
        public double MargemLucro { get; set; }

        // Resultados
        public double CustoTotal => CustoFixo + (CustoVariavel * Quantidade);
        public double ReceitaTotal => PrecoVenda * Quantidade;
        public double Lucro => ReceitaTotal - CustoTotal;
        public double PontoEquilibrio => (PrecoVenda - CustoVariavel) != 0 ? CustoFixo / (PrecoVenda - CustoVariavel) : 0;

        public double PrecoIdeal => (CustoVariavel * (1 + MargemLucro / 100)) + (CustoFixo / Quantidade);
    }
}
