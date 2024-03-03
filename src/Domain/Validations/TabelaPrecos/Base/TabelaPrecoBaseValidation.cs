using FluentValidation;
using Domain.Entities;
using Domain.Validations;

namespace Domain.Validations.TabelaPrecos.Base
{
    public class TabelaPrecoBaseValidation : ValidationBase<TabelaPreco>
    {
        public TabelaPrecoBaseValidation()
        {
            ValidarId();
        }

        public void ValidarIdProduto()
        {
            RuleFor(x => x.ProdutoId).NotNull().NotEmpty().WithMessage("Informe um Id de produto válido.");
        }

        public void ValidarPreco()
        {
            RuleFor(x => x.Preco).NotNull().NotEmpty().WithMessage("Informe um preço.");
        }
    }
}