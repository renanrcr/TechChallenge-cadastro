using MediatR;
using Domain.Entities;

namespace Application.Commands.TabelaPrecos
{
    public class DeletaTabelaPrecoCommand : IRequest<TabelaPreco>
    {
        public Guid Id { get; set; }
    }
}