using Domain.Validations.Produtos;

namespace Domain.Entities
{
    public class Produto : EntidadeBase<Guid>
    {
        public Guid CategoriaProdutoId { get; private set; }
        public string? Nome { get; private set; }
        public string? Descricao { get; private set; }
        public CategoriaProduto? CategoriaProduto { get; private set; }
        public TabelaPreco? TabelaPreco { get; private set; }

        public async Task<Produto> Cadastrar(Guid categoriaProdutoId, string? nome, string? descricao)
        {
            Id = Guid.NewGuid();
            CategoriaProdutoId = categoriaProdutoId;
            Nome = nome;
            Descricao = descricao;
            DataCadastro = DateTime.Now;
            TabelaPreco = await new TabelaPreco().Cadastrar(Id, 0m);

            await Validate(this, new CadastraProdutoValidation());

            return this;
        }

        public async Task<Produto> Atualizar(Guid id, Guid categoriaProdutoId, string? nome, string? descricao, TabelaPreco? tabelaPreco)
        {
            Id = id;
            CategoriaProdutoId = categoriaProdutoId;
            Nome = nome;
            Descricao = descricao;
            DataAtualizacao = DateTime.Now;
            TabelaPreco = tabelaPreco;

            await Validate(this, new AtualizaProdutoValidation());

            return this;
        }

        public async Task<Produto> Deletar(Produto produto)
        {
            await Atualizar(produto.Id, produto.CategoriaProdutoId, produto.Nome, produto.Descricao, produto.TabelaPreco);

            DataExclusao = DateTime.Now;

            await Validate(this, new DeletaProdutoValidation());

            return this;
        }
    }
}