namespace ADOProject_API.Domain.Models
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public string? Nome { get; set; }
        public decimal? Preco { get; set; }
        public int? Quantidade { get; set; }
        public string? Descricao { get; set; }
    }
}

