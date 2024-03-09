using Application.AutoMapper;
using Application.Commands.Produtos;
using AutoMapper;
using Domain.Adapters;
using Infrastructure.Tests.Adapters;
using MediatR;
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
        public void Produto_DeveRetornarVerdadeiro_ListarProdutos()
        {
            //Arrange
            var command = new CadastraProdutoCommand()
            {
                CategoriaProdutoId = Guid.NewGuid(),
                Nome = "Lanche",
                Descricao = "Cadastro do primeiro Lanche",
            };
            var resultPost = _produtoController.Post(command).Result;

            //Act
            var result = _produtoController.Get().Result;

            //Assert
            Assert.NotNull(resultPost);
            Assert.NotNull(result);
        }

        [Fact]
        public void Pedido_DeveRetornarVerdadeiro_QuandoCriarPedido()
        {
            //Arrange
            var command = new CadastraProdutoCommand()
            {
                CategoriaProdutoId = Guid.NewGuid(),
                Nome = "Lanche",
                Descricao = "Cadastro do primeiro Lanche",
            };

            //Act
            var result = _produtoController.Post(command).Result;

            //Assert
            Assert.NotNull(result);
        }
    }
}
