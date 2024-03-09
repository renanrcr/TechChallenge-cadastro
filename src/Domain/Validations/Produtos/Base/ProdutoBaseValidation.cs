using FluentValidation;
using Domain.Entities;
using Domain.ValueObjects;

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
            RuleFor(x => x.Nome)
                .MustAsync(ValidarStringNulOuVazia).WithMessage(MensagemRetorno.ProdutoInformeUmNome);
        }

        public void ValidarDescricao()
        {
            RuleFor(x => x.Descricao)
                .MustAsync(ValidarStringNulOuVazia).WithMessage(MensagemRetorno.ProdutoInformeUmaDescricao);
        }
    }
}