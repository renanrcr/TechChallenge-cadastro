using Domain.Validations.TabelaPrecos;

namespace Domain.Entities
{
    public class TabelaPreco : EntidadeBase<Guid>
    {
        public Guid ProdutoId { get; set; }
        public decimal? Preco { get; private set; }
        public Produto? Produto { get; private set; }

        public async Task<TabelaPreco> Cadastrar(Guid produtoId, decimal? preco)
        {
            Id = Guid.NewGuid();
            ProdutoId = produtoId;
            Preco = preco;
            DataCadastro = DateTime.Now;

            await Validate(this, new CadastraTabelaPrecoValidation());

            return this;
        }

        public async Task<TabelaPreco> Atualizar(Guid id, Guid produtoId, decimal? preco)
        {
            Id = id;
            ProdutoId = produtoId;
            Preco = preco;
            DataAtualizacao = DateTime.Now;

            await Validate(this, new AtualizaTabelaPrecoValidation());

            return this;
        }

        public async Task<TabelaPreco> Deletar(Guid id)
        {
            Id = id;
            DataExclusao = DateTime.Now;

            await Validate(this, new DeletaTabelaPrecoValidation());

            return this;
        }
    }
}