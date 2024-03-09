using Application.AutoMapper;
using Application.Commands.CategoriaProdutos;
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
    public class CategoriaProdutoControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<INotificador> _notification;
        private readonly IMapper _mapper;
        private readonly CategoriaProdutoController _categoriaProdutoController;
        private readonly ICategoriaProdutoRepository _categoriaProdutoRepository;

        public CategoriaProdutoControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _notification = new Mock<INotificador>();
            _categoriaProdutoRepository = ICategoriaProdutoRepositoryMock.GetMock();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperConfig>());
            _mapper = config.CreateMapper();

            _categoriaProdutoController = new CategoriaProdutoController(_notification.Object, _mediatorMock.Object, _mapper, _categoriaProdutoRepository);
        }

        [Fact]
        public async void CategoriaProduto_DeveRetornarVerdadeiro_ListarCategoriaProduto()
        {
            //Arrange
            var command = new CadastraCategoriaProdutoCommand()
            {
                Descricao = "Lanche",
            };
            _mediatorMock.Setup(x => x.Send(It.IsAny<CadastraCategoriaProdutoCommand>(), It.IsAny<CancellationToken>()))
               .ReturnsAsync(new CategoriaProdutoDTO
               {
                   Id = Guid.NewGuid(),
                   Descricao = command.Descricao,
               });
            var resultPost = await _categoriaProdutoController.Post(command);

            //Act
            var result = await _categoriaProdutoController.Get();

            //Assert
            Assert.NotNull(resultPost);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CategoriaProduto_DeveRetornarVerdadeiro_QuandoCriarCategoriaProdutoAsync()
        {
            //Arrange
            var command = new CadastraCategoriaProdutoCommand()
            {
                Descricao = "Lanche",
            };
            _mediatorMock.Setup(x => x.Send(It.IsAny<CadastraCategoriaProdutoCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CategoriaProdutoDTO
                {
                    Id = Guid.NewGuid(),
                    Descricao = command.Descricao,
                });

            //Act
            var result = await _categoriaProdutoController.Post(command);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CategoriaProduto_DeveRetornarVerdadeiro_QuandoDeletarCategoriaProdutoAsync()
        {
            //Arrange
            var commandCadastrar = new CadastraCategoriaProdutoCommand()
            {
                Descricao = "Lanche",
            };

            _mediatorMock.Setup(x => x.Send(It.IsAny<CadastraCategoriaProdutoCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CategoriaProdutoDTO
                {
                    Id = Guid.NewGuid(),
                    Descricao = commandCadastrar.Descricao,
                });
            _mediatorMock.Setup(x => x.Send(It.IsAny<DeletaCategoriaProdutoCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CategoriaProdutoDTO
                {
                    Id = Guid.NewGuid(),
                    Descricao = commandCadastrar.Descricao,
                });

            var resultPost = await _categoriaProdutoController.Post(commandCadastrar);

            var objectResult = Assert.IsType<OkObjectResult>(resultPost);
            var categoriaProdutoRetornado = Assert.IsType<CategoriaProdutoDTO>(objectResult.Value);

            var command = new DeletaCategoriaProdutoCommand() { Id = categoriaProdutoRetornado.Id, };

            //Act
            var result = await _categoriaProdutoController.Delete(command);

            //Assert
            Assert.NotNull(result);
        }
    }
}
