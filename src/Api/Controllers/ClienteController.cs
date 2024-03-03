using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TechChallenge.Api.Controllers.Base;
using Domain.Adapters;
using Application.DTOs;
using Application.Commands.Clientes;
using Swashbuckle.AspNetCore.Annotations;

namespace TechChallenge.Api.Controllers
{
    [Route("Cadastro")]
    [SwaggerTag("Cliente - endpoint responsável pela consulta e cadastro dos clientes.")]
    [SwaggerResponse(200, "Sucesso na requisição.", typeof(IEnumerable<ClienteDTO>))]
    [SwaggerResponse(404, "Não encontrou nenhum registro para a requisição.")]
    [SwaggerResponse(400, "Não pode processar a requisição.")]
    [SwaggerResponse(500, "Erro na requisição.")]
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

        [HttpGet("clientes")]
        [SwaggerOperation(Summary = "Clientes", Description = "Retorna todos os clientes cadastrados.")]
        public async Task<IActionResult?> Get()
        {
            if (!ModelState.IsValid) return null;

            return Ok(_mapper.Map<IEnumerable<ClienteDTO>>(await _clienteRepository.ObterTodos()));
        }

        [HttpPost("clientes")]
        [SwaggerOperation(Summary = "Cadastrar clientes", Description = "Cadastra o cliente.")]
        public async Task<IActionResult?> Post(CadastraClienteCommand command)
        {
            if (!ModelState.IsValid) return null;

            var entidade = await _mediator.Send(command);

            if (!IsOperacaoValida) return BadRequest(ObterNotificacoes());

            return Ok(entidade);
        }

        [HttpPut("clientes")]
        [SwaggerOperation(Summary = "Atualizar clientes", Description = "Atualiza os dados do cliente cadastrado.")]
        public async Task<IActionResult?> Put(AtualizaClienteCommand command)
        {
            if (!ModelState.IsValid) return null;

            var entidade = await _mediator.Send(command);

            if (!IsOperacaoValida) return BadRequest(ObterNotificacoes());

            return Ok(entidade);
        }

        [HttpDelete("clientes")]
        [SwaggerOperation(Summary = "Deletar clientes", Description = "Deleta o cliente informado.")]
        public async Task<IActionResult?> Delete(DeletaClienteCommand command)
        {
            if (!ModelState.IsValid) return null;

            var entidade = await _mediator.Send(command);

            if (!IsOperacaoValida) return BadRequest(ObterNotificacoes());

            return Ok(entidade);
        }
    }
}