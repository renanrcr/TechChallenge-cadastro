using Domain.Entities;

namespace Domain.Tests.Validations.Produtos
{
    public class ProdutoTest
    {
        public ProdutoTest()
        {
        }

        [Fact]
        public async Task Produto_DeveRetornarFalso_QuandoNaoExistirDescricao()
        {
            //Arrange
            var categoria = await new CategoriaProduto().Cadastrar("Categoria Lanche");

            //Act
            var novoDado = new Produto().Cadastrar(categoria.Id, "Lanche", string.Empty).Result;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(novoDado);
                Assert.False(novoDado.IsValid);
            });
        }

        [Fact]
        public async Task Produto_DeveRetornarFalso_QuandoNaoExistirNome()
        {
            //Arrange
            var categoria = await new CategoriaProduto().Cadastrar("Categoria Lanche");

            //Act
            var novoDado = new Produto().Cadastrar(categoria.Id, string.Empty, "Cadastro do primeiro Lanche").Result;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(novoDado);
                Assert.False(novoDado.IsValid);
            });
        }
    }
}