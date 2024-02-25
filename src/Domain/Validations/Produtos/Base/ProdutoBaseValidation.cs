using FluentValidation;
using Domain.Entities;
using Domain.Validations;

namespace Domain.Validations.Produtos.Base
{
    public class ProdutoBaseValidation : ValidationBase<Produto>
    {
        public ProdutoBaseValidation()
        {
            ValidarId();
        }

        public void ValidarNome()
        {
            RuleFor(x => x.Nome).NotNull().NotEmpty().WithMessage("Informe um nome.");
        }

        public void ValidarDescricao()
        {
            RuleFor(x => x.Descricao).NotNull().NotEmpty().WithMessage("Informe uma descrição.");
        }
    }
}