using Domain.Validations.CategoriaProdutos;

namespace Domain.Entities
{
    public class CategoriaProduto : EntidadeBase<Guid>
    {
        public string? Descricao { get; private set; }

        public Produto? Produto { get; private set; }

        public async Task<CategoriaProduto> Cadastrar(string? descricao)
        {
            Id = Guid.NewGuid();
            Descricao = descricao;
            DataCadastro = DateTime.Now;

            await Validate(this, new CadastraCategoriaProdutoValidation());

            return this;
        }

        public async Task<CategoriaProduto> Atualizar(Guid id, string? descricao)
        {
            Id = id;
            Descricao = descricao;
            DataAtualizacao = DateTime.Now;

            await Validate(this, new AtualizaCategoriaProdutoValidation());

            return this;
        }

        public async Task<CategoriaProduto> Deletar(Guid id)
        {
            Id = id;
            DataExclusao = DateTime.Now;

            await Validate(this, new DeletaCategoriaProdutoValidation());

            return this;
        }
    }
}