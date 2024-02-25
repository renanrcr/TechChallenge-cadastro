using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TechChallenge.Api.Controllers.Base;
using TechChallenge.Api.DTOs;
using TechChallenge.src.Core.Domain.Adapters;
using TechChallenge.src.Core.Domain.Commands.CategoriaProdutos;

namespace TechChallenge.Api.Controllers
{
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

        [HttpGet]
        public async Task<IActionResult?> Get()
        {
            if (!ModelState.IsValid) return null;

            return Ok(_mapper.Map<IEnumerable<CategoriaProdutoDTO>>(await _categoriaProdutoRepository.ObterTodos()));
        }

        [HttpPost]
        public async Task<IActionResult?> Post(CadastraCategoriaProdutoCommand command)
        {
            if (!ModelState.IsValid) return null;

            var entidade = await _mediator.Send(command);

            if (!IsOperacaoValida) return BadRequest(ObterNotificacoes());

            return Ok(entidade);
        }

        [HttpPut]
        public async Task<IActionResult?> Put(AtualizaCategoriaProdutoCommand command)
        {
            if (!ModelState.IsValid) return null;

            var entidade = await _mediator.Send(command);

            if (!IsOperacaoValida) return BadRequest(ObterNotificacoes());

            return Ok(entidade);
        }

        [HttpDelete]
        public async Task<IActionResult?> Delete(DeletaCategoriaProdutoCommand command)
        {
            if (!ModelState.IsValid) return null;

            var entidade = await _mediator.Send(command);

            if (!IsOperacaoValida) return BadRequest(ObterNotificacoes());

            return Ok(entidade);
        }
    }
}