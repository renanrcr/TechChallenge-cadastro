using FluentValidation;
using Domain.Entities;

namespace Domain.Validations.CategoriaProdutos.Base
{
    public class CategoriaProdutoBaseValidation : ValidationBase<CategoriaProduto>
    {
        public CategoriaProdutoBaseValidation()
        {
            ValidarId();
        }

        public void ValidarDescricao()
        {
            RuleFor(x => x.Descricao).Null().Empty().WithMessage("Informe uma descrição da categoria.");
        }
    }
}