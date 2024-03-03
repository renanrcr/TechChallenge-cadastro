using Application.DTOs;
using MediatR;

namespace Application.Commands.Produtos
{
    public class DeletaProdutoCommand : IRequest<ProdutoDTO>
    {
        public Guid Id { get; set; }
    }
}