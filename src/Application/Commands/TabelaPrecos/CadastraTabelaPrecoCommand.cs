using MediatR;
using Application.DTOs;

namespace Application.Commands.TabelaPrecos
{
    public class CadastraTabelaPrecoCommand : IRequest<TabelaPrecoDTO>
    {
        public Guid ProdutoId { get; set; }
        public decimal Preco { get; set; }
    }
}