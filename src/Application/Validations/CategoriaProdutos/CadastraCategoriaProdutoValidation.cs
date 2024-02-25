using TechChallenge.src.Core.Application.Validations.CategoriaProdutos.Base;

namespace TechChallenge.src.Core.Application.Validations.CategoriaProdutos
{
    public class CadastraCategoriaProdutoValidation : CategoriaProdutoBaseValidation
    {
        public CadastraCategoriaProdutoValidation()
        {
            ValidarDataCadastro();
            ValidarDescricao();
        }
    }
}