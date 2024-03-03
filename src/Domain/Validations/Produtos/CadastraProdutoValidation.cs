using Domain.Validations.Produtos.Base;

namespace Domain.Validations.Produtos
{
    public class CadastraProdutoValidation : ProdutoBaseValidation
    {
        public CadastraProdutoValidation()
        {
            ValidarId();
        }
    }
}