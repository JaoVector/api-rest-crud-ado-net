using ADOProject_API.DbContext;
using ADOProject_API.Domain.DTOS;
using ADOProject_API.Domain.Models;
using ADOProject_API.Repository.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace ADOProject_API.Repository.Classes
{
    public class ProdutoRepository : IRepository<Produto>, IProdutoRepository
    {

        private readonly IConfiguration _configuration;

        public ProdutoRepository(IConfiguration configuration)
        {
            _configuration= configuration;
        }

        public void Add(Produto entity)
        {
            using (var conexao = new SqlConnection(_configuration.GetConnectionString("ConnectionSQL")))
            {
               
                var query = "INSERT INTO Produtos (Nome,Preco,Quantidade,Descricao) VALUES (@Nome,@Preco,@Quantidade,@Descricao);";
                var cmd = new SqlCommand(query, conexao);
                cmd.CommandType = CommandType.Text;
                
                cmd.Parameters.AddWithValue("@Nome", entity.Nome);
                cmd.Parameters.AddWithValue("@Preco", entity.Preco);
                cmd.Parameters.AddWithValue("@Quantidade", entity.Quantidade);
                cmd.Parameters.AddWithValue("@Descricao", entity.Descricao);
               
                try
                {
                    conexao.Open();
                    int i = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    throw new Exception($"Erro ao Salvar os Dados: {ex}");
                }
                finally 
                { 
                    conexao.Close(); 
                }
            }
        }

        public Produto ConsultaPorId(int id)
        {
            Produto _produto = new Produto();

            using (var conexao = new SqlConnection(_configuration.GetConnectionString("ConnectionSQL"))) 
            {
                try
                {
                    var query = $"SELECT * FROM Produtos WHERE IdProduto = '{id}'";
                    var cmd = new SqlCommand(query.ToString(), conexao);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IdProduto", id);

                    conexao.Open();

                    using (var reader = cmd.ExecuteReader()) 
                    {
                        while (reader.Read()) 
                        {
                            _produto.IdProduto = Convert.ToInt32(reader["IdProduto"]);
                            _produto.Nome = reader["Nome"].ToString();
                            _produto.Quantidade = Convert.ToInt32(reader["Quantidade"]);
                            _produto.Preco = Convert.ToDecimal(reader["Preco"]);
                            _produto.Descricao = reader["Descricao"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {

                    throw new Exception($"Erro ao Consultar os Dados: {ex}");

                } finally 
                {
                    conexao.Close(); 
                }
            }

            return _produto;
        }

        public IQueryable<Produto> ConsultaProdutos(int limite)
        {

            List<Produto> _produtos = new List<Produto>();
            using (var conexao = new SqlConnection(_configuration.GetConnectionString("ConnectionSQL"))) 
            {
                try
                {
                    var query = $"SELECT TOP({limite}) * FROM Produtos";
                    var cmd = new SqlCommand(query.ToString(), conexao);
                    cmd.CommandType = CommandType.Text;

                    conexao.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _produtos.Add(new Produto
                            {
                                IdProduto = Convert.ToInt32(reader["IdProduto"]),
                                Nome = reader["Nome"].ToString(),
                                Quantidade = Convert.ToInt32(reader["Quantidade"]),
                                Preco = Convert.ToDecimal(reader["Preco"]),
                                Descricao = reader["Descricao"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {

                    throw new Exception($"Erro ao Consultar os Dados: {ex}");
                }
                finally 
                { 
                    conexao.Close(); 
                }
            }

            return _produtos.AsQueryable();
        }

        public void Delete(int id)
        {
            using(var conexao = new SqlConnection(_configuration.GetConnectionString("ConnectionSQL"))) 
            {
                try
                {
                    var query = $"DELETE FROM Produtos WHERE IdProduto= '{id}'";
                    var cmd = new SqlCommand(query, conexao);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IdProduto", id);

                    conexao.Open();

                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {

                    throw new Exception($"Erro ao Deletar dados: {ex}");

                } finally 
                { 
                    conexao.Close(); 
                }
            }
        }

        public void Update(int id, Produto entity)
        {
            using (var conexao = new SqlConnection(_configuration.GetConnectionString("ConnectionSQL"))) 
            {
                try
                {
                    var query = $"UPDATE Produtos SET Nome=@Nome, Preco=@Preco, Quantidade=@Quantidade," +
                                $" Descricao=@Descricao WHERE IdProduto = '{id}'";
                    var cmd = new SqlCommand(query, conexao);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@IdProduto", id);
                    cmd.Parameters.AddWithValue("@Nome", entity.Nome);
                    cmd.Parameters.AddWithValue("@Quantidade", entity.Quantidade);
                    cmd.Parameters.AddWithValue("@Preco", entity.Preco);
                    cmd.Parameters.AddWithValue("@Descricao", entity.Descricao);

                    conexao.Open();
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {

                    throw new Exception($"Erro ao Atualizar os dados: {ex}");
                } finally 
                { 
                    conexao.Close(); 
                }
            }
        }

        public IQueryable<ReadProdutoDTO> ProdutosMaisBaratos()
        {
            List<ReadProdutoDTO> _prodtuos = new List<ReadProdutoDTO>();

            using (var conexao = new SqlConnection(_configuration.GetConnectionString("ConnectionSQL")))
            {
                try
                {
                    var query = "SELECT * FROM Produtos ORDER BY Preco ASC";
                    var cmd = new SqlCommand(query, conexao);
                    cmd.CommandType = CommandType.Text;

                    conexao.Open();

                    using (var reader = cmd.ExecuteReader()) 
                    {
                        while (reader.Read()) 
                        {
                            _prodtuos.Add(new ReadProdutoDTO()
                            {
                                IdProduto = Convert.ToInt32(reader["IdProduto"]),
                                Nome = reader["Nome"].ToString(),
                                Preco = Convert.ToDecimal(reader["Preco"]),
                                Quantidade = Convert.ToInt32(reader["Quantidade"]),
                                Descricao = reader["Descricao"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {

                    throw new Exception($"Erro ao Consultar os dados: {ex}");
                }
                finally 
                { 
                    conexao.Close(); 
                }
            }

            return _prodtuos.AsQueryable();
        }

        public IQueryable<ReadProdutoDTO> ProdutosMaisCaros()
        {
           List<ReadProdutoDTO> _produtos = new List<ReadProdutoDTO>();
            using (var conexao = new SqlConnection(_configuration.GetConnectionString("ConnectionSQL")))
            {
                try
                {
                    var query = "SELECT * FROM Produtos ORDER BY Preco DESC";
                    var cmd = new SqlCommand(query, conexao);
                    cmd.CommandType = CommandType.Text;

                    conexao.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _produtos.Add(new ReadProdutoDTO 
                            {
                                IdProduto = Convert.ToInt32(reader["IdProduto"]),
                                Nome = reader["Nome"].ToString(),
                                Preco = Convert.ToDecimal(reader["Preco"]),
                                Quantidade = Convert.ToInt32(reader["Quantidade"]),
                                Descricao = reader["Descricao"].ToString()
                                
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erro ao Consultar os dados: {ex}");
                } finally {
                    conexao.Close(); 
                }
            }
            return _produtos.AsQueryable();
        }

        public IQueryable<ReadProdutoDTO> ProdutosEntre15a50Reais()
        {
            List<ReadProdutoDTO> _produtos = new List<ReadProdutoDTO>();
            using (var conexao = new SqlConnection(_configuration.GetConnectionString("ConnectionSQL")))
            {
                try
                {
                    var query = "SELECT * FROM Produtos WHERE Preco BETWEEN 15 AND 50";
                    var cmd = new SqlCommand(query, conexao);
                    cmd.CommandType = CommandType.Text;

                    conexao.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _produtos.Add(new ReadProdutoDTO
                            {
                                IdProduto = Convert.ToInt32(reader["IdProduto"]),
                                Nome = reader["Nome"].ToString(),
                                Preco = Convert.ToDecimal(reader["Preco"]),
                                Quantidade = Convert.ToInt32(reader["Quantidade"]),
                                Descricao = reader["Descricao"].ToString()

                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erro ao Consultar os dados: {ex}");
                }
                finally
                {
                    conexao.Close();
                }
            }
            return _produtos.AsQueryable();
        }

        public IQueryable<ReadProdutoDTO> ProdutosPrecoAcima50()
        {
            List<ReadProdutoDTO> _produtos = new List<ReadProdutoDTO>();
            using (var conexao = new SqlConnection(_configuration.GetConnectionString("ConnectionSQL")))
            {
                try
                {
                    var query = "SELECT * FROM Produtos WHERE Preco > 50";
                    var cmd = new SqlCommand(query, conexao);
                    cmd.CommandType = CommandType.Text;

                    conexao.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _produtos.Add(new ReadProdutoDTO
                            {
                                IdProduto = Convert.ToInt32(reader["IdProduto"]),
                                Nome = reader["Nome"].ToString(),
                                Preco = Convert.ToDecimal(reader["Preco"]),
                                Quantidade = Convert.ToInt32(reader["Quantidade"]),
                                Descricao = reader["Descricao"].ToString()

                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erro ao Consultar os dados: {ex}");
                }
                finally
                {
                    conexao.Close();
                }
            }
            return _produtos.AsQueryable();
        }
    }
}
