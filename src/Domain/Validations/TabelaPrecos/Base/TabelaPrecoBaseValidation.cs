using FluentValidation;
using Domain.Entities;
using Domain.ValueObjects;

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
            RuleFor(x => x.ProdutoId).NotNull().NotEmpty().WithMessage(MensagemRetorno.TabelaPrecoInformeUmProduto);
        }

        public void ValidarPreco()
        {
            RuleFor(x => x.Preco).NotNull().NotEmpty().NotEqual(0).WithMessage(MensagemRetorno.TabelaPrecoInformeUmPreco);
        }
    }
}