using Domain.Adapters;
using Domain.Entities;
using Infrastructure.Tests.Adapters;

namespace Infrastructure.Tests.Repositories
{
    public class ProdutoRepositoryTests
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaProdutoRepository _categoriaProdutoRepository;

        public ProdutoRepositoryTests()
        {
            _produtoRepository = IProdutoRepositoryMock.GetMock();
            _categoriaProdutoRepository = ICategoriaProdutoRepositoryMock.GetMock();
        }

        [Fact]
        public async Task Produto_DeveRetornarVerdadeiro_QuandoCriarNovo()
        {
            //Arrange
            var categoria = await new CategoriaProduto().Cadastrar(_categoriaProdutoRepository, "Categoria Lanche");
            var novoDado = await new Produto().Cadastrar(categoria.Id, "Lanche", "Cadastro do primeiro Lanche");

            //Act
            await _produtoRepository.Adicionar(novoDado);
            var dadoCriado = await _produtoRepository.ObterPorId(novoDado.Id);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(dadoCriado);
                Assert.Equal(dadoCriado.Id, novoDado.Id);
            });
        }

        [Fact]
        public async Task Produto_DeveRetornarVerdadeiro_QuandoAtualizar()
        {
            //Arrange
            var categoria = await new CategoriaProduto().Cadastrar(_categoriaProdutoRepository, "Categoria Lanche");
            var novoDado = await new Produto().Cadastrar(categoria.Id, "Lanche", "Cadastro do primeiro Lanche");
            await _produtoRepository.Adicionar(novoDado);

            //Act
            await _produtoRepository.Atualizar(novoDado);
            var dadoAtualizado = await _produtoRepository.ObterPorId(novoDado.Id) ?? new();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(dadoAtualizado);
                Assert.Equal(novoDado.Id, dadoAtualizado.Id);
            });
        }

        [Fact]
        public async Task Produto_DeveRetornarVerdadeiro_QuandoTiverTodosAsIndentificacoes()
        {
            //Arrange
            var categoria = await new CategoriaProduto().Cadastrar(_categoriaProdutoRepository, "Categoria Lanche");
            var novoDado = await new Produto().Cadastrar(categoria.Id, "Lanche", "Cadastro do primeiro Lanche");
            await _produtoRepository.Adicionar(novoDado);

            //Act
            var dados = await _produtoRepository.ObterTodos();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(dados);
                Assert.True(dados.Count > 0);
            });
        }

        [Fact]
        public async Task Produto_DeveRetornarVerdadeiro_QuandoEncontrarPeloID()
        {
            //Arrange
            var categoria = await new CategoriaProduto().Cadastrar(_categoriaProdutoRepository, "Categoria Lanche");
            var novoDado = await new Produto().Cadastrar(categoria.Id, "Lanche", "Cadastro do primeiro Lanche");
            await _produtoRepository.Adicionar(novoDado);
            Guid id = ((await _produtoRepository.ObterTodos()).FirstOrDefault() ?? new()).Id;

            //Act
            var dado = await _produtoRepository.ObterPorId(id);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(dado);
                Assert.Equal(dado.Id, id);
            });
        }

        [Fact]
        public async Task Produto_DeveRetornarVerdadeiro_QuandoExcluir()
        {
            //Arrange
            var categoria = await new CategoriaProduto().Cadastrar(_categoriaProdutoRepository, "Categoria Lanche");
            var novoDado = await new Produto().Cadastrar(categoria.Id, "Lanche", "Cadastro do primeiro Lanche");
            await _produtoRepository.Adicionar(novoDado);
            var produto = await _produtoRepository.ObterPorId(novoDado.Id) ?? new();

            //Act
            var produtoExcluir = await new Produto().Deletar(produto);
            await _produtoRepository.Atualizar(produtoExcluir);

            //Assert
            Assert.NotEqual(DateTime.MinValue, produtoExcluir!.DataExclusao);
        }
    }
}
