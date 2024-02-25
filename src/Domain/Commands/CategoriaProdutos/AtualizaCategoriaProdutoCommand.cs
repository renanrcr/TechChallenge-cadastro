using MediatR;
using TechChallenge.Api.DTOs;

namespace TechChallenge.src.Core.Domain.Commands.CategoriaProdutos
{
    public class AtualizaCategoriaProdutoCommand : IRequest<CategoriaProdutoDTO>
    {
        public Guid Id { get; set; }
        public Guid ProdutoId { get; set; }
        public string? Descricao { get; set; }
    }
}