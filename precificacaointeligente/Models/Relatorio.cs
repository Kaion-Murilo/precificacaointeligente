namespace precificacaointeligente.Models
{
    public class Relatorio
    {
        public int IdRelatorio { get; set; }
        public int? IdUsuario { get; set; }
        public string Tipo { get; set; }
        public DateTime? PeriodoInicio { get; set; }
        public DateTime? PeriodoFim { get; set; }
        public string ArquivoPdf { get; set; }
        public DateTime DataGeracao { get; set; }

        public Usuario Usuario { get; set; }
    }
}
