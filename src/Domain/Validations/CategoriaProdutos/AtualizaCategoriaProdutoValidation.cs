using Domain.Validations.CategoriaProdutos.Base;

namespace Domain.Validations.CategoriaProdutos
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