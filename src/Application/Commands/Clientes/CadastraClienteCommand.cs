using Application.DTOs;
using MediatR;

namespace Application.Commands.Clientes
{
    public class CadastraClienteCommand : IRequest<ClienteDTO>
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
    }
}