using ADOProject_API.Domain.DTOS;
using ADOProject_API.Domain.Models;
using ADOProject_API.Repository.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ADOProject_API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProdutoController : ControllerBase
    {

        private readonly IProdutoRepository _repository;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpPost]
        public IActionResult AdicionaProduto([FromBody] CreateProdutoDTO produto) 
        {

            Produto produtoMap = _mapper.Map<Produto>(produto);

            _repository.Add(produtoMap);

            return Ok(produtoMap);
        }

        [HttpGet]
        public IActionResult ConsultaProdutos([FromQuery] int limite = 5) 
        {
            var result = _repository.ConsultaProdutos(limite);

            if (result == null) return NotFound("Produtos não encontrados"); 

            var produtos = _mapper.Map<List<ReadProdutoDTO>>(result);

            return Ok(produtos);
        }

        [HttpGet("{id}", Name = "Obter Produto por Id")]
        public IActionResult ConsultaPorId(int id) 
        {
            var consulta = _repository.ConsultaPorId(id);

            if (consulta == null) return NotFound($"Não encontrado produto com {id}");
            
            return Ok(consulta);
        }

        [HttpGet("MaisCarosParaMaisBaratos", Name = "Obter Produtos mais Caros para Mais Baratos")]
        public ActionResult<IEnumerable<ReadProdutoDTO>> ConsultaMaisCaros() 
        {
            var consulta = _repository.ProdutosMaisCaros();

            if (consulta == null) return NotFound("Produtos Não Encontrados");

            var produtosCaros = _mapper.Map<List<ReadProdutoDTO>>(consulta);

            return Ok(produtosCaros);
        }

        [HttpGet("MaisBaratosParaMaisCaros", Name = "Obter Produtos mais Baratos para Mais Caros")]
        public ActionResult<IEnumerable<ReadProdutoDTO>> ConsultaMaisBaratos()
        {
            var consulta = _repository.ProdutosMaisBaratos();

            if (consulta == null) return NotFound("Produtos Não Encontrados");

            var produtosBaratos = _mapper.Map<List<ReadProdutoDTO>>(consulta);

            return Ok(produtosBaratos);
        }

        [HttpGet("ProdutosEntre15a50Reais", Name ="Produtos entre 15 a 50 reais")]
        public ActionResult<IEnumerable<ReadProdutoDTO>> ProdutosEntre15a50Reais() 
        {
            var consulta = _repository.ProdutosEntre15a50Reais();

            if (consulta == null) return NotFound("Produtos não encontrados");

            var produtos = _mapper.Map<List<ReadProdutoDTO>>(consulta);

            return Ok(produtos);
        }

        [HttpGet("ProdutosAcima50Reais", Name = "Produtos acima de 50 reais")]
        public ActionResult<IEnumerable<ReadProdutoDTO>> ProdutosPrecoAcima50()
        {
            var consulta = _repository.ProdutosPrecoAcima50();

            if (consulta == null) return NotFound("Produtos não encontrados");

            var produtos = _mapper.Map<List<ReadProdutoDTO>>(consulta);

            return Ok(produtos);
        }

        [HttpPut("{id}", Name ="Atualiza Produto")]
        public IActionResult AtualizaProduto(int id, [FromBody] UpdateProdutoDTO update) 
        {
            var consulta = _repository.ConsultaPorId(id);

            if (consulta == null) return NotFound($"Não encontrado produto com {id}");

            Produto prodUp = _mapper.Map<Produto>(update);
            _repository.Update(id, prodUp);

            return NoContent();
        }

        [HttpDelete("{id}", Name="Deleta Produto por ID")]
        public IActionResult DeletaProduto(int id) 
        {
            var consulta = _repository.ConsultaPorId(id);

            if (consulta == null) return NotFound($"Não encontrado produto com {id}");

            _repository.Delete(id);

            return Ok($"Produto Excluido de ID: {id}");
        }
    }
}
