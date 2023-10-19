namespace ADOProject_API.Domain.DTOS
{
    public class ReadProdutoDTO
    {
        public int? IdProduto { get; set; }
        public string? Nome { get; set; }
        public decimal? Preco { get; set; }
        public int? Quantidade { get; set; }
        public string? Descricao { get; set; }
    }
}
