using MediatR;
using Application.DTOs;

namespace Application.Commands.TabelaPrecos
{
    public class DeletaTabelaPrecoCommand : IRequest<TabelaPrecoDTO>
    {
        public Guid Id { get; set; }
    }
}