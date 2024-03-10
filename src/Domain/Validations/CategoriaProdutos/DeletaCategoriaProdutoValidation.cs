using Domain.Adapters;
using Domain.Validations.CategoriaProdutos.Base;

namespace Domain.Validations.CategoriaProdutos
{
    public class DeletaCategoriaProdutoValidation : CategoriaProdutoBaseValidation
    {
        public DeletaCategoriaProdutoValidation(ICategoriaProdutoRepository categoriaProdutoRepository)
            : base(categoriaProdutoRepository)
        {
            ValidarDataExclusao();
        }
    }
}