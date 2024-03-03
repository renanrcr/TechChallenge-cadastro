using MediatR;
using Domain.Entities;

namespace Application.Commands.TabelaPrecos
{
    public class AtualizaTabelaPrecoCommand : IRequest<TabelaPreco>
    {
        public Guid Id { get; set; }
        public Guid ProdutoId { get; set; }
        public decimal Preco { get; set; }
    }
}