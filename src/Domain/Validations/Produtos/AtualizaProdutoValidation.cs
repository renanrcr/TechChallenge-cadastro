using Domain.Validations.Produtos.Base;

namespace Domain.Validations.Produtos
{
    public class AtualizaProdutoValidation : ProdutoBaseValidation
    {
        public AtualizaProdutoValidation()
        {
            ValidarDataAtualizacao();
            ValidarNome();
            ValidarDescricao();
        }
    }
}