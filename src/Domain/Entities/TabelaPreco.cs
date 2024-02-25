using TechChallenge.src.Core.Application.Validations.TabelaPrecos;
using TechChallenge.src.Core.Domain.Adapters;
using TechChallenge.src.Core.Domain.Commands.TabelaPrecos;

namespace TechChallenge.src.Core.Domain.Entities
{
    public class TabelaPreco : EntidadeBase<Guid>
    {
        public Guid ProdutoId { get; set; }
        public decimal Preco { get; private set; }
        public Produto? Produto { get; private set; }

        public async Task<TabelaPreco> Cadastrar(CadastraTabelaPrecoCommand command)
        {
            Id = Guid.NewGuid();
            ProdutoId = command.ProdutoId;
            Preco = command.Preco;
            DataCadastro = DateTime.Now;

            await Validate(this, new CadastraTabelaPrecoValidation());

            return this;
        }

        public async Task<TabelaPreco> Atualizar(AtualizaTabelaPrecoCommand command)
        {
            Id = command.Id;
            ProdutoId = command.ProdutoId;
            Preco = command.Preco;
            DataAtualizacao = DateTime.Now;

            await Validate(this, new AtualizaTabelaPrecoValidation());

            return this;
        }

        public async Task<TabelaPreco> Deletar(DeletaTabelaPrecoCommand command)
        {
            Id = command.Id;
            DataExclusao = DateTime.Now;

            await Validate(this, new DeletaTabelaPrecoValidation());

            return this;
        }
    }
}