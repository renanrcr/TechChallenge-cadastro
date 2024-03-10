using Domain.Adapters;
using Domain.Validations.CategoriaProdutos.Base;

namespace Domain.Validations.CategoriaProdutos
{
    public class CadastraCategoriaProdutoValidation : CategoriaProdutoBaseValidation
    {
        public CadastraCategoriaProdutoValidation(ICategoriaProdutoRepository categoriaProdutoRepository)
            : base(categoriaProdutoRepository)
        {
            ValidarDataCadastro();
            ValidarDescricao();
        }
    }
}