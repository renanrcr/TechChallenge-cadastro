using Application.AutoMapper;
using Application.Commands.TabelaPrecos;
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
    public class TabelaPrecoControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<INotificador> _notification;
        private readonly IMapper _mapper;
        private readonly TabelaPrecoController _tabelaPrecoController;
        private readonly ITabelaPrecoRepository _tabelaPrecoRepository;

        public TabelaPrecoControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _notification = new Mock<INotificador>();
            _tabelaPrecoRepository = ITabelaPrecoRepositoryMock.GetMock();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperConfig>());
            _mapper = config.CreateMapper();

            _tabelaPrecoController = new TabelaPrecoController(_notification.Object, _mediatorMock.Object, _mapper, _tabelaPrecoRepository);
        }

        [Fact]
        public async void TabelaPreco_DeveRetornarVerdadeiro_ListarTabelasDePreco()
        {
            //Arrange
            var command = new CadastraTabelaPrecoCommand()
            {
                ProdutoId = Guid.NewGuid(),
                Preco = 21.49m,
            };

            _mediatorMock.Setup(x => x.Send(It.IsAny<CadastraTabelaPrecoCommand>(), It.IsAny<CancellationToken>()))
               .ReturnsAsync(new TabelaPrecoDTO
               {
                   Id = Guid.NewGuid(),
                   Preco = 21.49m,
               });

            var resultPost = await _tabelaPrecoController.Post(command);

            //Act
            var result = await _tabelaPrecoController.Get();

            //Assert
            Assert.NotNull(resultPost);
            Assert.NotNull(result);
        }

        [Fact]
        public async void TabelaPreco_DeveRetornarVerdadeiro_QuandoCriarPreco()
        {
            //Arrange
            var command = new CadastraTabelaPrecoCommand()
            {
                ProdutoId = Guid.NewGuid(),
                Preco = 21.49m,
            };

            _mediatorMock.Setup(x => x.Send(It.IsAny<CadastraTabelaPrecoCommand>(), It.IsAny<CancellationToken>()))
               .ReturnsAsync(new TabelaPrecoDTO
               {
                   Id = Guid.NewGuid(),
                   Preco = 21.49m,
               });

            //Act
            var result = await _tabelaPrecoController.Post(command);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async void TabelaPreco_DeveRetornarFalse_QuandoNaoTiverPreco()
        {
            //Arrange
            var command = new CadastraTabelaPrecoCommand()
            {
                ProdutoId = Guid.NewGuid(),
                Preco = 0m,
            };

            _mediatorMock.Setup(x => x.Send(It.IsAny<CadastraTabelaPrecoCommand>(), It.IsAny<CancellationToken>()))
               .ReturnsAsync(new TabelaPrecoDTO
               {
                   Id = Guid.NewGuid(),
                   Preco = 0m,
               });

            //Act
            var result = await _tabelaPrecoController.Post(command);

            //Assert
            Assert.False(_notification.Object.TemNotificacao());
        }

        [Fact]
        public async void TabelaPreco_DeveRetornarVerdadeiro_QuandoDeletarPreco()
        {
            //Arrange
            var commandCadastrar = new CadastraTabelaPrecoCommand()
            {
                ProdutoId = Guid.NewGuid(),
                Preco = 21.49m,
            };

            _mediatorMock.Setup(x => x.Send(It.IsAny<CadastraTabelaPrecoCommand>(), It.IsAny<CancellationToken>()))
               .ReturnsAsync(new TabelaPrecoDTO
               {
                   Id = Guid.NewGuid(),
                   Preco = 21.49m,
               });

            _mediatorMock.Setup(x => x.Send(It.IsAny<DeletaTabelaPrecoCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new TabelaPrecoDTO
                {
                    Id = Guid.NewGuid(),
                    Preco = 21.49m,
                });

            var resultPost = await _tabelaPrecoController.Post(commandCadastrar);

            var objectResult = Assert.IsType<OkObjectResult>(resultPost);
            var tabelaPrecoRetornada = Assert.IsType<TabelaPrecoDTO>(objectResult.Value);

            var command = new DeletaTabelaPrecoCommand() { Id = tabelaPrecoRetornada.Id, };

            //Act
            var result = await _tabelaPrecoController.Delete(command);

            //Assert
            Assert.NotNull(result);
        }
    }
}
