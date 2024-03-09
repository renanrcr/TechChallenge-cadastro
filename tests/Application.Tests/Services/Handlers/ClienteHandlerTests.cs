using Application.AutoMapper;
using Application.Commands.Clientes;
using AutoMapper;
using Domain.Adapters;
using Domain.Notificacoes;
using Infrastructure.Tests.Adapters;
using TechChallenge.src.Handlers;

namespace Application.Tests.Services.Handlers
{
    public class ClienteHandlerTests
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly INotificador _notificador;
        private readonly IMapper _mapper;
        private readonly ClienteHandler _clienteHandler;

        public ClienteHandlerTests()
        {
            _clienteRepository = IClienteRepositoryMock.GetMock();
            _notificador = new Notificador();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperConfig>());
            _mapper = config.CreateMapper();

            _clienteHandler = new ClienteHandler(_notificador, _clienteRepository, _mapper);
        }

        [Fact]
        public void Cliente_DeveRetornarVerdadeiro_QuandoCadastrarNovo()
        {
            //Arrange
            var command = new CadastraClienteCommand()
            {
                Nome = "Cliente I",
                Email = "cliente@mail.com",
            };

            //Act
            var result = _clienteHandler.Handle(command, default);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Cliente_DeveRetornarVerdadeiro_QuandoAtualizar()
        {
            //Arrange
            var commandCadastrar = new CadastraClienteCommand()
            {
                Nome = "Cliente I",
                Email = "cliente@mail.com",
            };
            var dado = _clienteHandler.Handle(commandCadastrar, default).Result;

            var command = new AtualizaClienteCommand()
            {
                Id = dado.Id,
                Nome = dado.Nome,
                Email = "cliente_1@mail.com",
            };

            //Act
            var result = _clienteHandler.Handle(command, default);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Cliente_DeveRetornarVerdadeiro_QuandoRemover()
        {
            //Arrange
            var commandCadastrar = new CadastraClienteCommand()
            {
                Nome = "Cliente I",
                Email = "cliente@mail.com",
            };
            var dado = _clienteHandler.Handle(commandCadastrar, default).Result;

            var command = new DeletaClienteCommand()
            {
                Id = dado.Id,
            };

            //Act
            var result = _clienteHandler.Handle(command, default);

            //Assert
            Assert.NotNull(result);
        }
    }
}
