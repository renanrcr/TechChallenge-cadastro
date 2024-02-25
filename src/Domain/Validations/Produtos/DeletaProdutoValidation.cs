using Domain.Validations.Produtos.Base;

namespace Domain.Validations.Produtos
{
    public class DeletaProdutoValidation : ProdutoBaseValidation
    {
        public DeletaProdutoValidation()
        {
            ValidarDataExclusao();
        }
    }
}