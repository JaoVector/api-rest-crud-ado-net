# API Rest utilizando ADO Net
## Descrição
O projeto tem a finalidade de apresentar a implementação do Ado Net para efetuar um CRUD, abordando 
o padrão de projeto Repository.
#
### Rotas da Aplicação
+ POST https://localhost:7206/api/Produto
+ GET https://localhost:7206/api/Produto
+ GET https://localhost:7206/api/Produto/{id}
+ PUT https://localhost:7206/api/Produto/{id}
+ DELETE https://localhost:7206/api/Produto/{id}
#
### Consultas Personalizadas
+ GET https://localhost:7206/api/Produto/MaisCarosParaMaisBaratos
+ GET https://localhost:7206/api/Produto/MaisBaratosParaMaisCaros
+ GET https://localhost:7206/api/Produto/ProdutosEntre15a50Reais
+ GET https://localhost:7206/api/Produto/ProdutosAcima50Reais
#
### Corpo Requisição POST e PUT
```json
{
  "nome": "string",
  "preco": 0,
  "quantidade": 0,
  "descricao": "string"
}
```
#
### Modelo de Dados da Entidade Produto
+ __IdProduto__ Tem o objetivo de identificar a entidade em cada uma das ações.
+ __Nome__ Inclui um rótulo ao produto para que seja identificado.
+ __Preco__ Aplica um valor monetário ao Produto.
+ __Quantidade__ Apresenta o número de unidades de um Produto.
+ __Descricao__ É o descritivo para especificar o que é o Produto.
#
## Definição de ADO Net Segundo a [Microsoft](https://learn.microsoft.com/pt-br/dotnet/framework/data/adonet/)
O ADO.NET é um conjunto de classes que expõem serviços de acesso a dados para desenvolvedores do .NET Framework. 
O ADO.NET fornece um conjunto rico de componentes para criar aplicativos distribuídos e de compartilhamento de dados. Faz parte do .NET Framework, fornecendo acesso a dados de aplicativo relacionais e XML. 
O ADO.NET oferece suporte a uma variedade de necessidades de desenvolvimento, incluindo a criação de clientes front-end de banco de dados e objetos comerciais de camada intermediária usados por aplicativos, ferramentas, linguagens ou navegadores da Internet.
