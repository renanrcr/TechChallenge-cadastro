using Application.DTOs;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;

namespace Application.Commands.Produtos
{
    public class AtualizaProdutoCommand : IRequest<ProdutoDTO>
    {
        [SwaggerSchema(
            Title = "Id",
            Description = "Id do produto",
            Format = "Guid")]
        public Guid Id { get; set; }

        [SwaggerSchema(
            Title = "CategoriaProdutoId",
            Description = "Id da categoria do produto",
            Format = "Guid")]
        public Guid CategoriaProdutoId { get; set; }

        [SwaggerSchema(
            Title = "Nome",
            Description = "Nome do produto",
            Format = "string")]
        public string? Nome { get; set; }

        [SwaggerSchema(
            Title = "Descricao",
            Description = "Descrição do produto",
            Format = "string")]
        public string? Descricao { get; set; }
    }
}