using Application.DTOs;
using MediatR;

namespace Application.Commands.Clientes
{
    public class AtualizaClienteCommand : IRequest<ClienteDTO>
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
    }
}