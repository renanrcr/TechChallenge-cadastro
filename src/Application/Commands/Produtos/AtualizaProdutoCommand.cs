using Application.DTOs;
using MediatR;

namespace Application.Commands.Produtos
{
    public class AtualizaProdutoCommand : IRequest<ProdutoDTO>
    {
        public Guid Id { get; set; }
        public Guid CategoriaProdutoId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
    }
}