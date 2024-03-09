using Application.DTOs;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;

namespace Application.Commands.CategoriaProdutos
{
    public class DeletaCategoriaProdutoCommand : IRequest<CategoriaProdutoDTO>
    {
        [SwaggerSchema(
            Title = "Id",
            Description = "Id da categoria do produto",
            Format = "Guid")]
        public Guid Id { get; set; }
    }
}