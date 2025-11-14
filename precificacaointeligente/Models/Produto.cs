using precificacaointeligente.Models;

public class Produto
{
    public int IdProduto { get; set; }
    public string Nome { get; set; }
    public string Categoria { get; set; }
    public decimal CustoFixo { get; set; }
    public decimal CustoVariavel { get; set; }
    public decimal? MargemLucro { get; set; }
    public decimal? PrecoSugerido { get; set; }
    public int Estoque { get; set; }
    public DateTime DataCadastro { get; set; }

    public int? IdLinha { get; set; }
    public LinhaProducao Linha { get; set; }

    public ICollection<Producao> Producoes { get; set; }
    public ICollection<Precificacao> Precificacoes { get; set; }
    public ICollection<Venda> Vendas { get; set; }
}
