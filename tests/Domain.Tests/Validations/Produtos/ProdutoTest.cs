using Domain.Adapters;
using Domain.Entities;
using Domain.ValueObjects;
using Infrastructure.Tests.Adapters;

namespace Domain.Tests.Validations.Produtos
{
    public class ProdutoTest
    {
        private readonly ICategoriaProdutoRepository _categoriaProdutoRepository;

        public ProdutoTest()
        {
            _categoriaProdutoRepository = ICategoriaProdutoRepositoryMock.GetMock();
        }

        [Fact]
        public async Task Produto_DeveRetornarFalso_QuandoNaoExistirDescricao()
        {
            //Arrange
            var categoria = await new CategoriaProduto().Cadastrar(_categoriaProdutoRepository, "Categoria Lanche");

            //Act
            var novoDado = await new Produto().Cadastrar(categoria.Id, "Lanche", string.Empty);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(novoDado);
                Assert.False(novoDado.IsValid);
                Assert.True(novoDado.ValidationResult.Errors.Exists(x => x.ErrorMessage.Contains(MensagemRetorno.ProdutoInformeUmaDescricao)));
            });
        }

        [Fact]
        public async Task Produto_DeveRetornarFalso_QuandoNaoExistirNome()
        {
            //Arrange
            var categoria = await new CategoriaProduto().Cadastrar(_categoriaProdutoRepository, "Categoria Lanche");

            //Act
            var novoDado = await new Produto().Cadastrar(categoria.Id, string.Empty, "Cadastro do primeiro Lanche");

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(novoDado);
                Assert.False(novoDado.IsValid);
                Assert.True(novoDado.ValidationResult.Errors.Exists(x => x.ErrorMessage.Contains(MensagemRetorno.ProdutoInformeUmNome)));
            });
        }

        [Fact]
        public async Task Produto_DeveRetornarVerdadeiro_QuandoEstiverValido()
        {
            //Arrange
            var categoria = await new CategoriaProduto().Cadastrar(_categoriaProdutoRepository, "Categoria Lanche");

            //Act
            var novoDado = await new Produto().Cadastrar(categoria.Id, "Lanche", "Cadastro do primeiro Lanche");

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(novoDado);
                Assert.True(novoDado.IsValid);
            });
        }
    }
}