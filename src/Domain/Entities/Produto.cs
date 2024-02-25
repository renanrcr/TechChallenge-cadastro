using TechChallenge.src.Core.Application.Validations.Produtos;
using TechChallenge.src.Core.Domain.Commands.Produtos;

namespace TechChallenge.src.Core.Domain.Entities
{
    public class Produto : EntidadeBase<Guid>
    {
        public Guid CategoriaProdutoId { get; private set; }
        public string? Nome { get; private set; }
        public string? Descricao { get; private set; }
        public CategoriaProduto? CategoriaProduto { get; private set; }
        public TabelaPreco TabelaPreco { get; private set; } = new TabelaPreco();

        public async Task<Produto> Cadastrar(CadastraProdutoCommand command)
        {
            Id = Guid.NewGuid();
            CategoriaProdutoId = command.CategoriaProdutoId;
            Nome = command.Nome;
            Descricao = command.Descricao;
            DataCadastro = DateTime.Now;

            await Validate(this, new CadastraProdutoValidation());

            return this;
        }

        public async Task<Produto> Atualizar(AtualizaProdutoCommand command)
        {
            Id = command.Id;
            CategoriaProdutoId = command.CategoriaProdutoId;
            Nome = command.Nome;
            Descricao = command.Descricao;
            DataAtualizacao = DateTime.Now;

            await Validate(this, new AtualizaProdutoValidation());

            return this;
        }

        public async Task<Produto> Deletar(DeletaProdutoCommand command)
        {
            Id = command.Id;
            DataExclusao = DateTime.Now;

            await Validate(this, new DeletaProdutoValidation());

            return this;
        }
    }
}