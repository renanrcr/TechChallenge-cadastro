using Domain.Validations.CategoriaProdutos.Base;

namespace Domain.Validations.CategoriaProdutos
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