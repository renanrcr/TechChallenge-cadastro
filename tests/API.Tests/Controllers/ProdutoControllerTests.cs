using Application.AutoMapper;
using Application.Commands.Clientes;
using Application.Commands.Produtos;
using Application.DTOs;
using AutoMapper;
using Domain.Adapters;
using Infrastructure.Tests.Adapters;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TechChallenge.Api.Controllers;

namespace API.Tests.Controllers
{
    public class ProdutoControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<INotificador> _notification;
        private readonly IMapper _mapper;
        private readonly ProdutoController _produtoController;
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _notification = new Mock<INotificador>();
            _produtoRepository = IProdutoRepositoryMock.GetMock();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperConfig>());
            _mapper = config.CreateMapper();

            _produtoController = new ProdutoController(_notification.Object, _mediatorMock.Object, _produtoRepository, _mapper);
        }

        [Fact]
        public async void Produto_DeveRetornarVerdadeiro_ListarProdutos()
        {
            //Arrange
            var command = new CadastraProdutoCommand()
            {
                CategoriaProdutoId = Guid.NewGuid(),
                Nome = "Lanche",
                Descricao = "Cadastro do primeiro Lanche",
            };

            _mediatorMock.Setup(x => x.Send(It.IsAny<CadastraProdutoCommand>(), It.IsAny<CancellationToken>()))
               .ReturnsAsync(new ProdutoDTO
               {
                   Id = Guid.NewGuid(),
                   Nome = command.Nome,
                   Descricao = command.Descricao,
               });

            var resultPost = await _produtoController.Post(command);

            //Act
            var result = await _produtoController.Get();

            //Assert
            Assert.NotNull(resultPost);
            Assert.NotNull(result);
        }

        [Fact]
        public async void Produto_DeveRetornarVerdadeiro_QuandoCriarProduto()
        {
            //Arrange
            var command = new CadastraProdutoCommand()
            {
                CategoriaProdutoId = Guid.NewGuid(),
                Nome = "Lanche",
                Descricao = "Cadastro do primeiro Lanche",
            };

            _mediatorMock.Setup(x => x.Send(It.IsAny<CadastraProdutoCommand>(), It.IsAny<CancellationToken>()))
               .ReturnsAsync(new ProdutoDTO
               {
                   Id = Guid.NewGuid(),
                   Nome = command.Nome,
                   Descricao = command.Descricao,
               });

            //Act
            var result = await _produtoController.Post(command);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async void Produto_DeveRetornarVerdadeiro_QuandoDeletarProduto()
        {
            //Arrange
            var commandCadastrar = new CadastraProdutoCommand()
            {
                CategoriaProdutoId = Guid.NewGuid(),
                Nome = "Lanche",
                Descricao = "Cadastro do primeiro Lanche",
            };

            _mediatorMock.Setup(x => x.Send(It.IsAny<CadastraProdutoCommand>(), It.IsAny<CancellationToken>()))
               .ReturnsAsync(new ProdutoDTO
               {
                   Id = Guid.NewGuid(),
                   Nome = commandCadastrar.Nome,
                   Descricao = commandCadastrar.Descricao,
               });
            _mediatorMock.Setup(x => x.Send(It.IsAny<DeletaProdutoCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ProdutoDTO
                {
                    Id = Guid.NewGuid(),
                    Nome = commandCadastrar.Nome,
                    Descricao = commandCadastrar.Descricao,
                });

            var resultPost = await _produtoController.Post(commandCadastrar);

            var objectResult = Assert.IsType<OkObjectResult>(resultPost);
            var produtoRetornado = Assert.IsType<ProdutoDTO>(objectResult.Value);

            var command = new DeletaProdutoCommand() { Id = produtoRetornado.Id, };

            //Act
            var result = await _produtoController.Delete(command);

            //Assert
            Assert.NotNull(result);
        }
    }
}
