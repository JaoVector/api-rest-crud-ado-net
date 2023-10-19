namespace ADOProject_API.Domain.DTOS
{
    public class CreateProdutoDTO
    {
        public string? Nome { get; set; }
        public decimal? Preco { get; set; }
        public int? Quantidade { get; set; }
        public string? Descricao { get; set; }
    }
}
