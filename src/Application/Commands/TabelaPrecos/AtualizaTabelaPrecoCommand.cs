using MediatR;
using Application.DTOs;

namespace Application.Commands.TabelaPrecos
{
    public class AtualizaTabelaPrecoCommand : IRequest<TabelaPrecoDTO>
    {
        public Guid Id { get; set; }
        public decimal Preco { get; set; }
    }
}