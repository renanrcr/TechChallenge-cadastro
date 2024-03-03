using FluentValidation;
using Domain.Entities;
using Domain.Validations;

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
            RuleFor(x => x.Descricao).NotNull().NotEmpty().WithMessage("Informe uma descrição da categoria.");
        }
    }
}