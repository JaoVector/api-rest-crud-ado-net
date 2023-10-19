using ADOProject_API.Domain.DTOS;
using ADOProject_API.Domain.Models;

namespace ADOProject_API.Repository.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        IQueryable<ReadProdutoDTO> ProdutosMaisCaros();
        IQueryable<ReadProdutoDTO> ProdutosMaisBaratos();
        IQueryable<ReadProdutoDTO> ProdutosEntre15a50Reais();
        IQueryable<ReadProdutoDTO> ProdutosPrecoAcima50();
    }
}
