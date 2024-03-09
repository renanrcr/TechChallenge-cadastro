using Application.DTOs;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;

namespace Application.Commands.CategoriaProdutos
{
    public class AtualizaCategoriaProdutoCommand : IRequest<CategoriaProdutoDTO>
    {
        [SwaggerSchema(
            Title = "Id",
            Description = "Id da categoria do produto",
            Format = "Guid")]
        public Guid Id { get; set; }

        [SwaggerSchema(
            Title = "Descricao",
            Description = "Descrição do produto",
            Format = "string")]
        public string? Descricao { get; set; }
    }
}