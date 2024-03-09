using Application.DTOs;

namespace Application.Tests.DTOs
{
    public class ProdutoDTOTests
    {
        [Fact]
        public void ProdutoDTO_DeveRetornarVerdadeiro()
        {
            // Arrange
            string nome = "Lanche";
            string descricao = "Cadastro do primeiro Lanche";

            // Act
            var produtoDTO = new ProdutoDTO
            {
                Id = Guid.NewGuid(),
                CategoriaProdutoId = Guid.NewGuid(),
                Nome = nome,
                Descricao = descricao,
            };

            // Assert
            Assert.Equal(nome, produtoDTO.Nome);
            Assert.Equal(descricao, produtoDTO.Descricao);
        }
    }
}
