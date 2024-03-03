using Application.DTOs;
using MediatR;

namespace Application.Commands.Clientes
{
    public class DeletaClienteCommand : IRequest<ClienteDTO>
    {
        public Guid Id { get; set; }
    }
}