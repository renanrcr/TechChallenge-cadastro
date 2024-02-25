using FluentValidation;
using TechChallenge.src.Core.Domain.Entities;

namespace TechChallenge.src.Core.Application.Validations.CategoriaProdutos.Base
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