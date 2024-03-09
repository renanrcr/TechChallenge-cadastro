using Domain.Adapters;
using Domain.Validations.CategoriaProdutos.Base;

namespace Domain.Validations.CategoriaProdutos
{
    public class AtualizaCategoriaProdutoValidation : CategoriaProdutoBaseValidation
    {
        public AtualizaCategoriaProdutoValidation(ICategoriaProdutoRepository categoriaProdutoRepository)
            : base(categoriaProdutoRepository)
        {
            ValidarDescricao();
            ValidarDataAtualizacao();
        }
    }
}