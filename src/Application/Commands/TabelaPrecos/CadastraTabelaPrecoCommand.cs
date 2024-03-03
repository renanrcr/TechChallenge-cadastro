using MediatR;
using Domain.Entities;

namespace Application.Commands.TabelaPrecos
{
    public class CadastraTabelaPrecoCommand : IRequest<TabelaPreco>
    {
        public Guid ProdutoId { get; set; }
        public decimal Preco { get; set; }
    }
}