using Domain.Adapters;
using Domain.Entities;
using Infrastructure.Tests.Adapters;

namespace Domain.Tests.Validations.Clientes
{
    public class ClienteTest
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteTest()
        {
            _clienteRepository = IClienteRepositoryMock.GetMock();
        }

        [Fact]
        public async Task Cliente_DeveRetornarFalso_QuandoNaoExistirNome()
        {
            //Arrange

            //Act
            var novoDado = await new Cliente().Cadastrar(_clienteRepository, null, "cliente@mail.com", string.Empty);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(novoDado);
                Assert.False(novoDado.IsValid);
            });
        }

        [Fact]
        public async Task Cliente_DeveRetornarVerdadeiro_QuandoNaoExistirEmail()
        {
            //Arrange

            //Act
            var novoDado = await new Cliente().Cadastrar(_clienteRepository, "Cliente I", string.Empty, string.Empty);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(novoDado);
                Assert.True(novoDado.IsValid);
            });
        }
    }
}