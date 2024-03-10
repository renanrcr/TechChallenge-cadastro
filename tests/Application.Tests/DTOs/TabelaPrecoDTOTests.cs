using Application.DTOs;

namespace Application.Tests.DTOs
{
    public class TabelaPrecoDTOTests
    {
        [Fact]
        public void TabelaPrecoDTO_DeveRetornarVerdadeiro()
        {
            // Arrange
            decimal preco = 22.99m;

            // Act
            var produtoDTO = new TabelaPrecoDTO
            {
                Id = Guid.NewGuid(),
                Preco = preco
            };

            // Assert
            Assert.Equal(preco, produtoDTO.Preco);
        }
    }
}
