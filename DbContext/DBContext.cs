namespace ADOProject_API.DbContext
{
    public class DBContext
    {
        public string? DbString { get; set; }
    }
}

/*
 *CREATE TABLE Produtos (
	IdProduto int identity(1,1),
	Nome varchar(225),
	Preco decimal(4,2),
	Quantidade smallint,
	Descricao varchar(max)
) 
 * 
 * 
*/