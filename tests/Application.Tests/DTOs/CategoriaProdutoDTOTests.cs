using Application.DTOs;

namespace Application.Tests.DTOs
{
    public class CategoriaProdutoDTOTests
    {
        [Fact]
        public void CategoriaProdutoDTO_DeveRetornarVerdadeiro()
        {
            // Arrange
            string descricao = "Categoria Lanche";

            // Act
            var categoriaProdutoDTO = new CategoriaProdutoDTO
            {
                Id = Guid.NewGuid(),
                Descricao = descricao,
            };

            // Assert
            Assert.Equal(descricao, categoriaProdutoDTO.Descricao);
        }
    }
}
