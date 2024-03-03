using Application.DTOs;
using MediatR;

namespace Application.Commands.CategoriaProdutos
{
    public class CadastraCategoriaProdutoCommand : IRequest<CategoriaProdutoDTO>
    {
        public string? Descricao { get; set; }
    }
}