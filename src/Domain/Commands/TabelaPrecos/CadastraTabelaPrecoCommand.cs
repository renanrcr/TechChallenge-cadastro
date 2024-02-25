using MediatR;
using TechChallenge.src.Core.Domain.Entities;

namespace TechChallenge.src.Core.Domain.Commands.TabelaPrecos
{
    public class CadastraTabelaPrecoCommand : IRequest<TabelaPreco>
    {
        public Guid ProdutoId { get; set; }
        public decimal Preco { get; set; }
    }
}