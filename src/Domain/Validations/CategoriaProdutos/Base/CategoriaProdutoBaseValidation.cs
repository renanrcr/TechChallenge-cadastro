using FluentValidation;
using Domain.Entities;
using Domain.Adapters;
using Domain.ValueObjects;

namespace Domain.Validations.CategoriaProdutos.Base
{
    public class CategoriaProdutoBaseValidation : ValidationBase<CategoriaProduto>
    {
        private readonly ICategoriaProdutoRepository _categoriaProdutoRepository;

        public CategoriaProdutoBaseValidation(ICategoriaProdutoRepository categoriaProdutoRepository)
        {
            _categoriaProdutoRepository = categoriaProdutoRepository;

            ValidarId();
        }

        public void ValidarDescricao()
        {
            RuleFor(x => x.Descricao)
                .MustAsync(ValidarStringNulOuVazia).WithMessage(MensagemRetorno.CategoriaInformeUmaDescricao)
                .MustAsync(ExisteDescricaoAsync).WithMessage(MensagemRetorno.CategoriaJaExiste);
        }

        private async Task<bool> ExisteDescricaoAsync(string? descricao, CancellationToken token)
        {
            bool existe = await _categoriaProdutoRepository.Existe(x => x.Descricao == descricao);

            return await Task.FromResult(!existe);
        }
    }
}