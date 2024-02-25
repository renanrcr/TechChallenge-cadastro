using MediatR;
using TechChallenge.Api.DTOs;

namespace TechChallenge.src.Core.Domain.Commands.CategoriaProdutos
{
    public class CadastraCategoriaProdutoCommand : IRequest<CategoriaProdutoDTO>
    {
        public string? Descricao { get; set; }
    }
}