using Domain.Adapters;
using Domain.Entities;
using Infrastructure.Tests.Adapters;

namespace Infrastructure.Tests.Repositories
{
    public class CategoriaProdutoRepositoryTests
    {
        private readonly ICategoriaProdutoRepository _categoriaProdutoRepository;

        public CategoriaProdutoRepositoryTests()
        {
            _categoriaProdutoRepository = ICategoriaProdutoRepositoryMock.GetMock();
        }

        [Fact]
        public async Task CategoriaProduto_DeveRetornarVerdadeiro_QuandoCriarNovo()
        {
            //Arrange
            var novoDado = await new CategoriaProduto().Cadastrar(_categoriaProdutoRepository, "Categoria Lanche");

            //Act
            await _categoriaProdutoRepository.Adicionar(novoDado);
            var dadoCriado = await _categoriaProdutoRepository.ObterPorId(novoDado.Id);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(dadoCriado);
                Assert.Equal(dadoCriado.Id, novoDado.Id);
            });
        }

        [Fact]
        public async Task CategoriaProduto_DeveRetornarVerdadeiro_QuandoAtualizar()
        {
            //Arrange
            var novoDado = await new CategoriaProduto().Cadastrar(_categoriaProdutoRepository, "Categoria Lanche");
            await _categoriaProdutoRepository.Adicionar(novoDado);

            Guid id = (_categoriaProdutoRepository.ObterTodos().Result.FirstOrDefault() ?? new()).Id;
            var dado = await _categoriaProdutoRepository.ObterPorId(id) ?? new();

            //Act
            await _categoriaProdutoRepository.Atualizar(dado);
            var dadoAtualizado = await _categoriaProdutoRepository.ObterPorId(dado.Id) ?? new();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(dadoAtualizado);
                Assert.Equal(dado.Id, dadoAtualizado.Id);
            });
        }

        [Fact]
        public async Task CategoriaProduto_DeveRetornarVerdadeiro_QuandoTiverTodosAsIndentificacoes()
        {
            //Arrange
            var novoDado = await new CategoriaProduto().Cadastrar(_categoriaProdutoRepository, "Categoria Lanche");
            await _categoriaProdutoRepository.Adicionar(novoDado);

            //Act
            var dados = await _categoriaProdutoRepository.ObterTodos();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(dados);
                Assert.True(dados.Count > 0);
            });
        }

        [Fact]
        public async Task CategoriaProduto_DeveRetornarVerdadeiro_QuandoEncontrarPeloID()
        {
            //Arrange
            var novoDado = await new CategoriaProduto().Cadastrar(_categoriaProdutoRepository, "Categoria Lanche");
            await _categoriaProdutoRepository.Adicionar(novoDado);
            Guid id = ((await _categoriaProdutoRepository.ObterTodos()).FirstOrDefault() ?? new()).Id;

            //Act
            var dado = await _categoriaProdutoRepository.ObterPorId(id);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(dado);
                Assert.Equal(dado.Id, id);
            });
        }
    }
}
