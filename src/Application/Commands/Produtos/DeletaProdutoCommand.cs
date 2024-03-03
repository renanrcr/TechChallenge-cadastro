using Application.DTOs;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;

namespace Application.Commands.Produtos
{
    public class DeletaProdutoCommand : IRequest<ProdutoDTO>
    {
        [SwaggerSchema(
            Title = "Id",
            Description = "Id do produto",
            Format = "Guid")]
        public Guid Id { get; set; }
    }
}