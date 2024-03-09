using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TechChallenge.Api.Controllers.Base;
using Domain.Adapters;
using Application.DTOs;
using Swashbuckle.AspNetCore.Annotations;
using Application.Commands.TabelaPrecos;

namespace TechChallenge.Api.Controllers
{
    [Route("TabelaPreco")]
    [SwaggerTag("Tabela de Preço - endpoint responsável pela consulta e cadastro dos preços dos produtos.")]
    [SwaggerResponse(200, "Sucesso na requisição.", typeof(IEnumerable<TabelaPrecoDTO>))]
    [SwaggerResponse(404, "Não encontrou nenhum registro para a requisição.")]
    [SwaggerResponse(400, "Não pode processar a requisição.")]
    [SwaggerResponse(500, "Erro na requisição.")]
    public class TabelaPrecoController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ITabelaPrecoRepository _tabelaPrecoRepository;

        public TabelaPrecoController(INotificador notificador,
            IMediator mediator,
            IMapper mapper,
            ITabelaPrecoRepository tabelaPrecoRepository)
            : base(notificador)
        {
            _mediator = mediator;
            _mapper = mapper;
            _tabelaPrecoRepository = tabelaPrecoRepository;
        }

        [HttpGet("precos")]
        [SwaggerOperation(Summary = "Preço dos Produtos", Description = "Retorna todos os preço cadastrados.")]
        public async Task<IActionResult?> Get()
        {
            if (!ModelState.IsValid) return null;

            return Ok(_mapper.Map<IEnumerable<TabelaPrecoDTO>>(await _tabelaPrecoRepository.ObterTodos()));
        }

        [HttpPost("preco")]
        [SwaggerOperation(Summary = "Cadastrar preço", Description = "Cadastra o preço do produto.")]
        public async Task<IActionResult?> Post([FromBody] CadastraTabelaPrecoCommand command)
        {
            if (!ModelState.IsValid) return null;

            var entidade = await _mediator.Send(command);

            if (!IsOperacaoValida) return BadRequest(ObterNotificacoes());

            return Ok(entidade);
        }

        [HttpPut("preco")]
        [SwaggerOperation(Summary = "Atualizar preço", Description = "Atualiza os preço do produto cadastrado.")]
        public async Task<IActionResult?> Put([FromBody] AtualizaTabelaPrecoCommand command)
        {
            if (!ModelState.IsValid) return null;

            var entidade = await _mediator.Send(command);

            if (!IsOperacaoValida) return BadRequest(ObterNotificacoes());

            return Ok(entidade);
        }

        [HttpDelete("preco")]
        [SwaggerOperation(Summary = "Deletar preço", Description = "Deleta o preço informado.")]
        public async Task<IActionResult?> Delete(DeletaTabelaPrecoCommand command)
        {
            if (!ModelState.IsValid) return null;

            var entidade = await _mediator.Send(command);

            if (!IsOperacaoValida) return BadRequest(ObterNotificacoes());

            return Ok(entidade);
        }
    }
}