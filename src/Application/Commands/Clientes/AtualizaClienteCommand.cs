using Application.DTOs;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;

namespace Application.Commands.Clientes
{
    public class AtualizaClienteCommand : IRequest<ClienteDTO>
    {
        [SwaggerSchema(
            Title = "Id",
            Description = "Id do cliente",
            Format = "Guid")]
        public Guid Id { get; set; }

        [SwaggerSchema(
            Title = "Nome",
            Description = "Nome do cliente",
            Format = "string")]
        public string? Nome { get; set; }

        [SwaggerSchema(
            Title = "Email",
            Description = "E-mail do cliente",
            Format = "string")]
        public string? Email { get; set; }
    }
}