using Application.DTOs;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;

namespace Application.Commands.Clientes
{
    public class CadastraClienteCommand : IRequest<ClienteDTO>
    {
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

        [SwaggerSchema(
            Title = "CPF",
            Description = "CPF do cliente",
            Format = "string")]
        public string? CPF { get; set; }
    }
}