using MediatR;
using TechChallenge.src.Core.Domain.Entities;

namespace TechChallenge.src.Core.Domain.Commands.TabelaPrecos
{
    public class DeletaTabelaPrecoCommand : IRequest<TabelaPreco>
    {
        public Guid Id { get; set; }
    }
}