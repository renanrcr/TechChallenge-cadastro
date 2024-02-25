using TechChallenge.src.Core.Application.Validations.Produtos.Base;

namespace TechChallenge.src.Core.Application.Validations.Produtos
{
    public class CadastraProdutoValidation : ProdutoBaseValidation
    {
        public CadastraProdutoValidation()
        {
            ValidarId();
        }
    }
}