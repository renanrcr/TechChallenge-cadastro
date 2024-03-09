using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TechChallenge.Api.Controllers.Base;
using Domain.Adapters;
using Application.DTOs;
using Application.Commands.CategoriaProdutos;
using Swashbuckle.AspNetCore.Annotations;

namespace TechChallenge.Api.Controllers
{
    [Route("Cadastro")]
    [SwaggerTag("Categoria do Produto - endpoint responsável pela consulta e cadastro das categorias.")]
    [SwaggerResponse(200, "Sucesso na requisição.", typeof(IEnumerable<CategoriaProdutoDTO>))]
    [SwaggerResponse(404, "Não encontrou nenhum registro para a requisição.")]
    [SwaggerResponse(400, "Não pode processar a requisição.")]
    [SwaggerResponse(500, "Erro na requisição.")]
    public class CategoriaProdutoController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ICategoriaProdutoRepository _categoriaProdutoRepository;

        public CategoriaProdutoController(INotificador notificador,
            IMediator mediator,
            IMapper mapper,
            ICategoriaProdutoRepository categoriaProdutoRepository)
            : base(notificador)
        {
            _mediator = mediator;
            _mapper = mapper;
            _categoriaProdutoRepository = categoriaProdutoRepository;
        }

        [HttpGet("categorias_produto")]
        [SwaggerOperation(Summary = "Categorias dos produtos", Description = "Retorna todos os produtos cadastrados.")]
        public async Task<IActionResult?> Get()
        {
            if (!ModelState.IsValid) return null;

            var categoriasProduto = await _categoriaProdutoRepository.ObterTodos();

            if (categoriasProduto.Count == 0) return NotFound(new CategoriaProdutoDTO());

            return Ok(_mapper.Map<IEnumerable<CategoriaProdutoDTO>>(categoriasProduto));
        }

        [HttpPost("categorias_produto")]
        [SwaggerOperation(Summary = "Cadastrar categoria do produto", Description = "Cadastra a categoria.")]
        public async Task<IActionResult?> Post(CadastraCategoriaProdutoCommand command)
        {
            if (!ModelState.IsValid) return null;

            var entidade = await _mediator.Send(command);

            if (!IsOperacaoValida) return BadRequest(ObterNotificacoes());

            return Ok(entidade);
        }

        [HttpPut("categorias_produto")]
        [SwaggerOperation(Summary = "Atualizar categoria do produto", Description = "Atualiza os dados da categoria cadastrado.")]
        public async Task<IActionResult?> Put(AtualizaCategoriaProdutoCommand command)
        {
            if (!ModelState.IsValid) return null;

            var entidade = await _mediator.Send(command);

            if (!IsOperacaoValida) return BadRequest(ObterNotificacoes());

            return Ok(entidade);
        }

        [HttpDelete("categorias_produto")]
        [SwaggerOperation(Summary = "Deletar categoria do produto", Description = "Deleta a categoria informado.")]
        public async Task<IActionResult?> Delete(DeletaCategoriaProdutoCommand command)
        {
            if (!ModelState.IsValid) return null;

            var entidade = await _mediator.Send(command);

            if (!IsOperacaoValida) return BadRequest(ObterNotificacoes());

            return Ok(entidade);
        }
    }
}