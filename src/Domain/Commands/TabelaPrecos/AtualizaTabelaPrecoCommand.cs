using MediatR;
using TechChallenge.src.Core.Domain.Entities;

namespace TechChallenge.src.Core.Domain.Commands.TabelaPrecos
{
    public class AtualizaTabelaPrecoCommand : IRequest<TabelaPreco>
    {
        public Guid Id { get; set; }
        public Guid ProdutoId { get; set; }
        public decimal Preco { get; set; }
    }
}