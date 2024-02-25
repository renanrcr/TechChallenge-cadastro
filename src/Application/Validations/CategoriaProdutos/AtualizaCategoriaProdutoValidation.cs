using TechChallenge.src.Core.Application.Validations.CategoriaProdutos.Base;

namespace TechChallenge.src.Core.Application.Validations.CategoriaProdutos
{
    public class AtualizaCategoriaProdutoValidation : CategoriaProdutoBaseValidation
    {
        public AtualizaCategoriaProdutoValidation()
        {
            ValidarDescricao();
            ValidarDataAtualizacao();
        }
    }
}