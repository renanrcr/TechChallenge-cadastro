using Domain.Adapters;
using Domain.Entities;
using Domain.ValueObjects;
using Infrastructure.Tests.Adapters;

namespace Domain.Tests.Validations.CategoriaProdutos
{
    public class CategoriaProdutoTest
    {
        private readonly ICategoriaProdutoRepository _categoriaProdutoRepository;

        public CategoriaProdutoTest()
        {
            _categoriaProdutoRepository = ICategoriaProdutoRepositoryMock.GetMock();
        }

        [Fact]
        public async Task CategoriaProduto_DeveRetornarFalso_QuandoNaoExistirDescricao()
        {
            //Arrange

            //Act
            var novoDado = await new CategoriaProduto().Cadastrar(_categoriaProdutoRepository, "");

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(novoDado);
                Assert.False(novoDado.IsValid);
                Assert.True(novoDado.ValidationResult.Errors.Exists(x => x.ErrorMessage.Contains(MensagemRetorno.CategoriaInformeUmaDescricao)));
            });
        }

        [Fact]
        public async Task CategoriaProduto_DeveRetornarFalso_QuandoADescricaoNull()
        {
            //Arrange

            //Act
            var novoDado = await new CategoriaProduto().Cadastrar(_categoriaProdutoRepository, null);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(novoDado);
                Assert.False(novoDado.IsValid);
                Assert.True(novoDado.ValidationResult.Errors.Exists(x => x.ErrorMessage.Contains(MensagemRetorno.CategoriaInformeUmaDescricao)));
            });
        }

        [Fact]
        public async Task CategoriaProduto_DeveRetornarFalso_QuandoADescricaoJaExiste()
        {
            //Arrange
            var categoriaCadastrar = await new CategoriaProduto().Cadastrar(_categoriaProdutoRepository, "Lanche");
            if (categoriaCadastrar.IsValid)
                await _categoriaProdutoRepository.Adicionar(categoriaCadastrar);

            //Act
            var novoDado = await new CategoriaProduto().Cadastrar(_categoriaProdutoRepository, "Lanche");

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(novoDado);
                Assert.False(novoDado.IsValid);
                Assert.True(novoDado.ValidationResult.Errors.Exists(x => x.ErrorMessage.Contains(MensagemRetorno.CategoriaJaExiste)));
            });
        }

        [Fact]
        public async Task CategoriaProduto_DeveRetornarVerdadeiro_QuandoEstiverValido()
        {
            //Arrange

            //Act
            var novoDado = await new CategoriaProduto().Cadastrar(_categoriaProdutoRepository, "Lanche");

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(novoDado);
                Assert.True(novoDado.IsValid);
            });
        }
    }
}