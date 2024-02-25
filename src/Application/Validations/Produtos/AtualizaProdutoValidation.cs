using TechChallenge.src.Core.Application.Validations.Produtos.Base;

namespace TechChallenge.src.Core.Application.Validations.Produtos
{
    public class AtualizaProdutoValidation : ProdutoBaseValidation
    {
        public AtualizaProdutoValidation()
        {
            ValidarDescricao();
            ValidarDataAtualizacao();
        }
    }
}