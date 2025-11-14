namespace precificacaointeligente.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string SenhaHash { get; set; }
        public string Cargo { get; set; }
        public DateTime DataCadastro { get; set; }

        public ICollection<Relatorio> Relatorios { get; set; }
    }
}
