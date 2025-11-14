namespace precificacaointeligente.Models
{
    public class LinhaProducao
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Produto> Produtos { get; set; }
    }
}
