using Application.DTOs;
using MediatR;

namespace Application.Commands.CategoriaProdutos
{
    public class AtualizaCategoriaProdutoCommand : IRequest<CategoriaProdutoDTO>
    {
        public Guid Id { get; set; }
        public Guid ProdutoId { get; set; }
        public string? Descricao { get; set; }
    }
}