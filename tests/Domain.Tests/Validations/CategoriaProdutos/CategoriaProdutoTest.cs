using Domain.Entities;

namespace Domain.Tests.Validations.CategoriaProdutos
{
    public class CategoriaProdutoTest
    {
        public CategoriaProdutoTest()
        {
        }

        [Fact]
        public async Task CategoriaProduto_DeveRetornarFalso_QuandoNaoExistirDescricao()
        {
            //Arrange

            //Act
            var novoDado = await new CategoriaProduto().Cadastrar("Categoria Lanche");

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(novoDado);
                Assert.False(novoDado.IsValid);
            });
        }
    }
}