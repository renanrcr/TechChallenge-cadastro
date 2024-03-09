using FluentValidation;
using Domain.Entities;

namespace Domain.Validations.Produtos.Base
{
    public class ProdutoBaseValidation : ValidationBase<Produto>
    {
        public ProdutoBaseValidation()
        {
            ValidarId();
            ValidarNome();
            ValidarDescricao();
        }

        public void ValidarNome()
        {
            RuleFor(x => x.Nome).Null().Empty().WithMessage("Informe um nome.");
        }

        public void ValidarDescricao()
        {
            RuleFor(x => x.Descricao).Null().Empty().WithMessage("Informe uma descrição.");
        }
    }
}