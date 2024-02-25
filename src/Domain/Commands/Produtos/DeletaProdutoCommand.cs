using MediatR;
using TechChallenge.Api.DTOs;

namespace TechChallenge.src.Core.Domain.Commands.Produtos
{
    public class DeletaProdutoCommand : IRequest<ProdutoDTO>
    {
        public Guid Id { get; set; }
    }
}