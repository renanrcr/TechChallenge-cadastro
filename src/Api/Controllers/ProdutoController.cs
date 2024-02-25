using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TechChallenge.Api.Controllers.Base;
using Domain.Adapters;
using Application.DTOs;
using Application.Commands.Produtos;

namespace TechChallenge.Api.Controllers
{
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

        [HttpGet]
        public async Task<IActionResult?> Get()
        {
            if (!ModelState.IsValid) return null;

            return Ok(_mapper.Map<IEnumerable<ProdutoDTO>>(await _produtoRepository.ObterTodos()));
        }

        [HttpGet]
        [Route("produto-por-categoria")]
        public async Task<IActionResult?> ObterProdutoPorCategoria(Guid categoriaId)
        {
            if (!ModelState.IsValid) return null;

            return Ok(_mapper.Map<IEnumerable<ProdutoDTO>>(await _produtoRepository.Buscar(x => x.CategoriaProdutoId == categoriaId)));
        }

        [HttpPost]
        public async Task<IActionResult?> Post(CadastraProdutoCommand command)
        {
            if (!ModelState.IsValid) return null;

            var entidade = await _mediator.Send(command);

            if (!IsOperacaoValida) return BadRequest(ObterNotificacoes());

            return Ok(entidade);
        }

        [HttpPut]
        public async Task<IActionResult?> Put(AtualizaProdutoCommand command)
        {
            if (!ModelState.IsValid) return null;

            var entidade = await _mediator.Send(command);

            if (!IsOperacaoValida) return BadRequest(ObterNotificacoes());

            return Ok(entidade);
        }

        [HttpDelete]
        public async Task<IActionResult?> Delete(DeletaProdutoCommand command)
        {
            if (!ModelState.IsValid) return null;

            var entidade = await _mediator.Send(command);

            if (!IsOperacaoValida) return BadRequest(ObterNotificacoes());

            return Ok(entidade);
        }
    }
}