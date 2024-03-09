using Application.DTOs;

namespace Application.Tests.DTOs
{
    public class ClienteDTOTests
    {
        [Fact]
        public void ClienteDTO_DeveRetornarVerdadeiro()
        {
            // Arrange
            string nome = "Cliente I";
            string email = "cliente@mail.com";

            // Act
            var clienteDTO = new ClienteDTO
            {
                Nome = nome,
                Email = email,
            };

            // Assert
            Assert.Equal(nome, clienteDTO.Nome);
            Assert.Equal(email, clienteDTO.Email);
        }
    }
}
