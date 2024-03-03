using Application.DTOs;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;

namespace Application.Commands.CategoriaProdutos
{
    public class CadastraCategoriaProdutoCommand : IRequest<CategoriaProdutoDTO>
    {
        [SwaggerSchema(
           Title = "Descricao",
           Description = "Descrição do produto",
           Format = "string")]
        public string? Descricao { get; set; }
    }
}