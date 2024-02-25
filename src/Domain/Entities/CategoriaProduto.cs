using TechChallenge.src.Core.Application.Validations.CategoriaProdutos;
using TechChallenge.src.Core.Domain.Commands.CategoriaProdutos;

namespace TechChallenge.src.Core.Domain.Entities
{
    public class CategoriaProduto : EntidadeBase<Guid>
    {
        public string? Descricao { get; private set; }

        public Produto? Produto { get; private set; }

        public async Task<CategoriaProduto> Cadastrar(CadastraCategoriaProdutoCommand command)
        {
            Id = Guid.NewGuid();
            Descricao = command.Descricao;
            DataCadastro = DateTime.Now;

            await Validate(this, new CadastraCategoriaProdutoValidation());

            return this;
        }

        public async Task<CategoriaProduto> Atualizar(AtualizaCategoriaProdutoCommand command)
        {
            Id = command.Id;
            Descricao = command.Descricao;
            DataAtualizacao = DateTime.Now;

            await Validate(this, new AtualizaCategoriaProdutoValidation());

            return this;
        }

        public async Task<CategoriaProduto> Deletar(DeletaCategoriaProdutoCommand command)
        {
            Id = command.Id;
            DataExclusao = DateTime.Now;

            await Validate(this, new DeletaCategoriaProdutoValidation());

            return this;
        }
    }
}