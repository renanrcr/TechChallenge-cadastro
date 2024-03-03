using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TechChallenge.Api.Controllers.Base;
using Domain.Adapters;
using Application.DTOs;
using Application.Commands.Produtos;
using Swashbuckle.AspNetCore.Annotations;

namespace TechChallenge.Api.Controllers
{
    [Route("Cadastro")]
    [SwaggerTag("Produto - endpoint responsável pela consulta e cadastro de produtos.")]
    [SwaggerResponse(200, "Sucesso na requisição.", typeof(IEnumerable<ProdutoDTO>))]
    [SwaggerResponse(404, "Não encontrou nenhum registro para a requisição.")]
    [SwaggerResponse(400, "Não pode processar a requisição.")]
    [SwaggerResponse(500, "Erro na requisição.")]
    public class ProdutoController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(INotificador notificador,
            IMediator mediator,
            IProdutoRepository produtoRepository,
            IMapper mapper)
            : base(notificador)
        {
            _mediator = mediator;
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        [HttpGet("produtos")]
        [SwaggerOperation(Summary = "Produtos", Description = "Retorna todos os produtos cadastrados.")]
        public async Task<IActionResult?> Get()
        {
            if (!ModelState.IsValid) return null;

            var produtos = await _produtoRepository.ObterTodos();

            if(produtos.Count == 0) return NotFound(new ProdutoDTO());

            return Ok(_mapper.Map<IEnumerable<ProdutoDTO>>(produtos));
        }

        [HttpGet("produto-por-categoria")]
        [SwaggerOperation(Summary = "Produtos por categoria", Description = "Retorna todos os produtos da categoria solicitada.")]
        public async Task<IActionResult?> ObterProdutoPorCategoria(Guid categoriaId)
        {
            if (!ModelState.IsValid) return null;

            return Ok(_mapper.Map<IEnumerable<ProdutoDTO>>(await _produtoRepository.Buscar(x => x.CategoriaProdutoId == categoriaId)));
        }

        [HttpPost("produtos")]
        [SwaggerOperation(Summary = "Cadastrar o produto", Description = "Cadastra o produto.")]
        public async Task<IActionResult?> Post([FromBody] CadastraProdutoCommand command)
        {
            if (!ModelState.IsValid) return null;

            var entidade = await _mediator.Send(command);

            if (!IsOperacaoValida) return BadRequest(ObterNotificacoes());

            return Ok(entidade);
        }

        [HttpPut("produtos")]
        [SwaggerOperation(Summary = "Atualizar o produto", Description = "Atualiza os dados do produto cadastrado.")]
        public async Task<IActionResult?> Put([FromBody] AtualizaProdutoCommand command)
        {
            if (!ModelState.IsValid) return null;

            var entidade = await _mediator.Send(command);

            if (!IsOperacaoValida) return BadRequest(ObterNotificacoes());

            return Ok(entidade);
        }

        [HttpDelete("produtos")]
        [SwaggerOperation(Summary = "Deletar o produto", Description = "Deleta o produto informado.")]
        public async Task<IActionResult?> Delete([FromRoute] DeletaProdutoCommand command)
        {
            if (!ModelState.IsValid) return null;

            var entidade = await _mediator.Send(command);

            if (!IsOperacaoValida) return BadRequest(ObterNotificacoes());

            return Ok(entidade);
        }
    }
}