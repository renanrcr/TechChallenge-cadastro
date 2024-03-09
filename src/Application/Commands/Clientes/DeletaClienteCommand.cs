using Application.DTOs;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;

namespace Application.Commands.Clientes
{
    public class DeletaClienteCommand : IRequest<ClienteDTO>
    {
        [SwaggerSchema(
            Title = "Id",
            Description = "Id do cliente",
            Format = "Guid")]
        public Guid Id { get; set; }
    }
}