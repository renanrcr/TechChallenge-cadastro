using TechChallenge.src.Core.Application.Validations.CategoriaProdutos.Base;

namespace TechChallenge.src.Core.Application.Validations.CategoriaProdutos
{
    public class DeletaCategoriaProdutoValidation : CategoriaProdutoBaseValidation
    {
        public DeletaCategoriaProdutoValidation()
        {
            ValidarDataExclusao();
        }
    }
}