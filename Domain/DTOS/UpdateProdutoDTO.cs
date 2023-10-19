namespace ADOProject_API.Domain.DTOS
{
    public class UpdateProdutoDTO
    {
        public string? Nome { get; set; }
        public decimal? Preco { get; set; }
        public int? Quantidade { get; set; }
        public string? Descricao { get; set; }
    }
}
