using Application.AutoMapper;
using Application.Commands.CategoriaProdutos;
using Application.Commands.Clientes;
using Application.DTOs;
using AutoMapper;
using Domain.Adapters;
using Infrastructure.Tests.Adapters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TechChallenge.Api.Controllers;

namespace API.Tests.Controllers
{
    public class ClienteControllerTest
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<INotificador> _notification;
        private readonly IMapper _mapper;
        private readonly ClienteController _clienteController;
        private readonly IClienteRepository _clienteRepository;

        public ClienteControllerTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _notification = new Mock<INotificador>();
            _clienteRepository = IClienteRepositoryMock.GetMock();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperConfig>());
            _mapper = config.CreateMapper();

            _clienteController = new ClienteController(_notification.Object, _mediatorMock.Object, _mapper, _clienteRepository);
        }

        [Fact]
        public async void Cliente_DeveRetornarVerdadeiro_ListarClientes()
        {
            //Arrange
            var command = new CadastraClienteCommand()
            {
                Nome = "Cliente I",
                Email = "cliente@mail.com",
            };

            _mediatorMock.Setup(x => x.Send(It.IsAny<CadastraClienteCommand>(), It.IsAny<CancellationToken>()))
               .ReturnsAsync(new ClienteDTO
               {
                   Id = Guid.NewGuid(),
                   Nome = command.Nome,
                   Email = command.Email,
               });

            var resultPost = await _clienteController.Post(command);

            //Act
            var result = await _clienteController.Get();

            //Assert
            Assert.NotNull(resultPost);
            Assert.NotNull(result);
        }

        [Fact]
        public async void Cliente_DeveRetornarVerdadeiro_QuandoCriarCliente()
        {
            //Arrange
            var command = new CadastraClienteCommand()
            {
                Nome = "Cliente I",
                Email = "cliente@mail.com",
            };

            _mediatorMock.Setup(x => x.Send(It.IsAny<CadastraClienteCommand>(), It.IsAny<CancellationToken>()))
               .ReturnsAsync(new ClienteDTO
               {
                   Id = Guid.NewGuid(),
                   Nome = command.Nome,
                   Email = command.Email,
               });

            //Act
            var result = await _clienteController.Post(command);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Cliente_DeveRetornarVerdadeiro_QuandoDeletarClienteAsync()
        {
            //Arrange
            var commandCadastrar = new CadastraClienteCommand()
            {
                Nome = "Cliente I",
                Email = "cliente@mail.com",
            };

            _mediatorMock.Setup(x => x.Send(It.IsAny<CadastraClienteCommand>(), It.IsAny<CancellationToken>()))
               .ReturnsAsync(new ClienteDTO
               {
                   Id = Guid.NewGuid(),
                   Nome = commandCadastrar.Nome,
                   Email = commandCadastrar.Email,
               });
            _mediatorMock.Setup(x => x.Send(It.IsAny<DeletaClienteCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ClienteDTO
                {
                    Id = Guid.NewGuid(),
                    Nome = commandCadastrar.Nome,
                    Email = commandCadastrar.Email,
                });

            var resultPost = await _clienteController.Post(commandCadastrar);

            var objectResult = Assert.IsType<OkObjectResult>(resultPost);
            var clienteRetornado = Assert.IsType<ClienteDTO>(objectResult.Value);

            var command = new DeletaClienteCommand() { Id = clienteRetornado.Id, };

            //Act
            var result = await _clienteController.Delete(command);

            //Assert
            Assert.NotNull(result);
        }
    }
}
