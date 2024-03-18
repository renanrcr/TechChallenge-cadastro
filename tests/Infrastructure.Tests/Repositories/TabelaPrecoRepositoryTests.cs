using Domain.Adapters;
using Domain.Entities;
using Infrastructure.Tests.Adapters;

namespace Infrastructure.Tests.Repositories
{
    public class TabelaPrecoRepositoryTests
    {
        private readonly ITabelaPrecoRepository _tabelaPrecoRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaProdutoRepository _categoriaProdutoRepository;

        public TabelaPrecoRepositoryTests()
        {
            _tabelaPrecoRepository = ITabelaPrecoRepositoryMock.GetMock();
            _produtoRepository = IProdutoRepositoryMock.GetMock();
            _categoriaProdutoRepository = ICategoriaProdutoRepositoryMock.GetMock();
        }

        [Fact]
        public async Task TabelaPreco_DeveRetornarVerdadeiro_QuandoCriarNovo()
        {
            //Arrange
            var categoria = await new CategoriaProduto().Cadastrar(_categoriaProdutoRepository, "Categoria Lanche");
            var produto = await new Produto().Cadastrar(categoria.Id, "Lanche", "Cadastro do primeiro Lanche");
            await _produtoRepository.Adicionar(produto);

            //Act
            var dado = await new TabelaPreco().Cadastrar(produto.Id, preco: 43.50m);
            await _tabelaPrecoRepository.Adicionar(dado);
            var dadoCriado = await _tabelaPrecoRepository.ObterPorId(dado.Id);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(dadoCriado);
                Assert.Equal(dadoCriado.Id, dado.Id);
            });
        }

        [Fact]
        public async Task TabelaPreco_DeveRetornarVerdadeiro_QuandoAtualizar()
        {
            //Arrange
            var categoria = await new CategoriaProduto().Cadastrar(_categoriaProdutoRepository, "Categoria Lanche");
            var produto = await new Produto().Cadastrar(categoria.Id, "Lanche", "Cadastro do primeiro Lanche");
            await _produtoRepository.Adicionar(produto); 
            var tabelaPreco = await new TabelaPreco().Cadastrar(produto.Id, preco: 43.50m);
            await _tabelaPrecoRepository.Adicionar(tabelaPreco);

            //Act
            await _tabelaPrecoRepository.Atualizar(tabelaPreco);
            var dadoAtualizado = await _tabelaPrecoRepository.ObterPorId(tabelaPreco.Id) ?? new();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(dadoAtualizado);
                Assert.Equal(tabelaPreco.Id, dadoAtualizado.Id);
            });
        }

        [Fact]
        public async Task TabelaPreco_DeveRetornarVerdadeiro_QuandoTiverTodosAsIndentificacoes()
        {
            //Arrange
            var categoria = await new CategoriaProduto().Cadastrar(_categoriaProdutoRepository, "Categoria Lanche");
            var produto = await new Produto().Cadastrar(categoria.Id, "Lanche", "Cadastro do primeiro Lanche");
            await _produtoRepository.Adicionar(produto);
            var tabelaPreco = await new TabelaPreco().Cadastrar(produto.Id, preco: 43.50m);
            await _tabelaPrecoRepository.Adicionar(tabelaPreco);

            //Act
            var dados = await _tabelaPrecoRepository.ObterTodos();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(dados);
                Assert.True(dados.Count > 0);
            });
        }

        [Fact]
        public async Task TabelaPreco_DeveRetornarVerdadeiro_QuandoEncontrarPeloID()
        {
            //Arrange
            var categoria = await new CategoriaProduto().Cadastrar(_categoriaProdutoRepository, "Categoria Lanche");
            var produto = await new Produto().Cadastrar(categoria.Id, "Lanche", "Cadastro do primeiro Lanche");
            await _produtoRepository.Adicionar(produto);
            var tabelaPreco = await new TabelaPreco().Cadastrar(produto.Id, preco: 43.50m);
            await _tabelaPrecoRepository.Adicionar(tabelaPreco);
            Guid id = ((await _tabelaPrecoRepository.ObterTodos()).FirstOrDefault() ?? new()).Id;

            //Act
            var dado = await _tabelaPrecoRepository.ObterPorId(id);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(dado);
                Assert.Equal(dado.Id, id);
            });
        }

        [Fact]
        public async Task TabelaPreco_DeveRetornarVerdadeiro_QuandoExcluir()
        {
            //Arrange
            var categoria = await new CategoriaProduto().Cadastrar(_categoriaProdutoRepository, "Categoria Lanche");
            var produto = await new Produto().Cadastrar(categoria.Id, "Lanche", "Cadastro do primeiro Lanche");
            await _produtoRepository.Adicionar(produto);
            var novoDado = await new TabelaPreco().Cadastrar(produto.Id, preco: 43.50m);
            await _tabelaPrecoRepository.Adicionar(novoDado);
            var tabelaPreco = await _tabelaPrecoRepository.ObterPorId(novoDado.Id) ?? new();

            //Act
            await _tabelaPrecoRepository.Remover(tabelaPreco);
            var dado = await _tabelaPrecoRepository.ObterPorId(tabelaPreco.Id);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.Null(dado);
            });
        }
    }
}
