using Domain.Adapters;
using Domain.Entities;
using Infrastructure.Tests.Adapters;

namespace Infrastructure.Tests.Repositories
{
    public class ClienteRepositoryTests
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteRepositoryTests()
        {
            _clienteRepository = IClienteRepositoryMock.GetMock();
        }

        [Fact]
        public async Task Cliente_DeveRetornarVerdadeiro_QuandoCriarNovo()
        {
            //Arrange
            var novoDado = await new Cliente().Cadastrar(_clienteRepository, "Cliente I", "cliente@mail.com", string.Empty);

            //Act
            await _clienteRepository.Adicionar(novoDado);
            var dadoCriado = await _clienteRepository.ObterPorId(novoDado.Id);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(dadoCriado);
                Assert.Equal(dadoCriado.Id, novoDado.Id);
            });
        }

        [Fact]
        public async Task Cliente_DeveRetornarVerdadeiro_QuandoAtualizar()
        {
            //Arrange
            var novoDado = await new Cliente().Cadastrar(_clienteRepository, "Cliente I", "cliente@mail.com", string.Empty);
            await _clienteRepository.Adicionar(novoDado);

            Guid id = ((await _clienteRepository.ObterTodos()).FirstOrDefault() ?? new()).Id;
            var dado = await _clienteRepository.ObterPorId(id) ?? new();

            //Act
            await _clienteRepository.Atualizar(dado);
            var dadoAtualizado = await _clienteRepository.ObterPorId(dado.Id) ?? new();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(dadoAtualizado);
                Assert.Equal(dado.Id, dadoAtualizado.Id);
            });
        }

        [Fact]
        public async Task Cliente_DeveRetornarVerdadeiro_QuandoTiverTodosAsIndentificacoes()
        {
            //Arrange
            var novoDado = await new Cliente().Cadastrar(_clienteRepository, "Cliente I", "cliente@mail.com", string.Empty);
            await _clienteRepository.Adicionar(novoDado);

            //Act
            var dados = await _clienteRepository.ObterTodos();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(dados);
                Assert.True(dados.Count > 0);
            });
        }

        [Fact]
        public async Task Cliente_DeveRetornarVerdadeiro_QuandoEncontrarPeloID()
        {
            //Arrange
            var novoDado = await new Cliente().Cadastrar(_clienteRepository, "Cliente I", "cliente@mail.com", string.Empty);
            await _clienteRepository.Adicionar(novoDado);
            Guid id = ((await _clienteRepository.ObterTodos()).FirstOrDefault() ?? new()).Id;

            //Act
            var dado = await _clienteRepository.ObterPorId(id);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(dado);
                Assert.Equal(dado.Id, id);
            });
        }

        [Fact]
        public async Task Cliente_DeveRetornarVerdadeiro_QuandoExcluir()
        {
            //Arrange
            var novoDado = await new Cliente().Cadastrar(_clienteRepository, "Cliente I", "cliente@mail.com", string.Empty);
            await _clienteRepository.Adicionar(novoDado);
            var cliente = await _clienteRepository.ObterPorId(novoDado.Id) ?? new();

            //Act
            await _clienteRepository.Remover(cliente);
            var clienteExcluido = await _clienteRepository.ObterPorId(novoDado.Id) ?? new();

            //Assert
            Assert.Equal(Guid.Empty, clienteExcluido.Id);
        }
    }
}
