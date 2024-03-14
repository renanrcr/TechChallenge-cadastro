using Domain.Adapters;
using Domain.Entities;
using Domain.ValueObjects;
using Infrastructure.Tests.Adapters;

namespace Domain.Tests.Validations.TabelasPreco
{
    public class TabelaPrecoTest
    {
        private readonly ICategoriaProdutoRepository _categoriaProdutoRepository;

        public TabelaPrecoTest()
        {
            _categoriaProdutoRepository = ICategoriaProdutoRepositoryMock.GetMock();
        }

        [Fact]
        public async Task TabelaPreco_DeveRetornarFalso_QuandoNaoExistirProduto()
        {
            //Arrange

            //Act
            var tabelaPreco = await new TabelaPreco().Cadastrar(Guid.Empty, 22m);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(tabelaPreco);
                Assert.False(tabelaPreco.IsValid);
                Assert.True(tabelaPreco.ValidationResult.Errors.Exists(x => x.ErrorMessage.Contains(MensagemRetorno.TabelaPrecoInformeUmProduto)));
            });
        }

        [Fact]
        public async Task TabelaPreco_DeveRetornarFalso_QuandoNaoExistirPreco()
        {
            //Arrange
            var categoria = await new CategoriaProduto().Cadastrar(_categoriaProdutoRepository, "Categoria Lanche");
            var produto = await new Produto().Cadastrar(categoria.Id, string.Empty, "Cadastro do primeiro Lanche");

            //Act
            var tabelaPreco = await new TabelaPreco().Cadastrar(produto.Id, 0m);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(tabelaPreco);
                Assert.False(tabelaPreco.IsValid);
                Assert.True(tabelaPreco.ValidationResult.Errors.Exists(x => x.ErrorMessage.Contains(MensagemRetorno.TabelaPrecoInformeUmPreco)));
            });
        }

        [Fact]
        public async Task TabelaPreco_DeveRetornarFalso_QuandoNaoEstiverValido()
        {
            //Arrange

            //Act
            var tabelaPreco = await new TabelaPreco().Cadastrar(Guid.NewGuid(), 0m);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(tabelaPreco);
                Assert.False(tabelaPreco.IsValid);
            });
        }
    }
}