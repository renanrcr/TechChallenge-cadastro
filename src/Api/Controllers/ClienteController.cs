using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TechChallenge.Api.Controllers.Base;
using TechChallenge.Api.DTOs;
using TechChallenge.src.Core.Domain.Adapters;
using TechChallenge.src.Core.Domain.Commands.Clientes;

namespace TechChallenge.Api.Controllers
{
    public class ClienteController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(INotificador notificador,
            IMediator mediator,
            IMapper mapper,
            IClienteRepository clienteRepository)
            : base(notificador)
        {
            _mediator = mediator;
            _mapper = mapper;
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public async Task<IActionResult?> Get()
        {
            if (!ModelState.IsValid) return null;

            return Ok(_mapper.Map<IEnumerable<ClienteDTO>>(await _clienteRepository.ObterTodos()));
        }

        [HttpPost]
        public async Task<IActionResult?> Post(CadastraClienteCommand command)
        {
            if (!ModelState.IsValid) return null;

            var entidade = await _mediator.Send(command);

            if (!IsOperacaoValida) return BadRequest(ObterNotificacoes());

            return Ok(entidade);
        }

        [HttpPut]
        public async Task<IActionResult?> Put(AtualizaClienteCommand command)
        {
            if (!ModelState.IsValid) return null;

            var entidade = await _mediator.Send(command);

            if (!IsOperacaoValida) return BadRequest(ObterNotificacoes());

            return Ok(entidade);
        }

        [HttpDelete]
        public async Task<IActionResult?> Delete(DeletaClienteCommand command)
        {
            if (!ModelState.IsValid) return null;

            var entidade = await _mediator.Send(command);

            if (!IsOperacaoValida) return BadRequest(ObterNotificacoes());

            return Ok(entidade);
        }
    }
}