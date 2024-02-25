using Application.DTOs;
using MediatR;

namespace Application.Commands.CategoriaProdutos
{
    public class DeletaCategoriaProdutoCommand : IRequest<CategoriaProdutoDTO>
    {
        public Guid Id { get; set; }
    }
}