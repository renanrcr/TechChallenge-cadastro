using Application.DTOs;
using MediatR;

namespace Application.Commands.Produtos
{
    public class CadastraProdutoCommand : IRequest<ProdutoDTO>
    {
        public Guid CategoriaProdutoId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
    }
}