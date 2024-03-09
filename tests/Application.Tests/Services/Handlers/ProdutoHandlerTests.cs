using Application.AutoMapper;
using Application.Commands.Produtos;
using AutoMapper;
using Domain.Adapters;
using Domain.Notificacoes;
using Infrastructure.Tests.Adapters;
using TechChallenge.src.Handlers;

namespace Application.Tests.Services.Handlers
{
    public class ProdutoHandlerTests
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly INotificador _notificador;
        private readonly IMapper _mapper;
        private readonly ProdutoHandler _produtoHandler;

        public ProdutoHandlerTests()
        {
            _produtoRepository = IProdutoRepositoryMock.GetMock();
            _notificador = new Notificador();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperConfig>());
            _mapper = config.CreateMapper();

            _produtoHandler = new ProdutoHandler(_notificador, _produtoRepository, _mapper);
        }

        [Fact]
        public void Produto_DeveRetornarVerdadeiro_QuandoCadastrarNovo()
        {
            //Arrange
            var command = new CadastraProdutoCommand()
            {
                CategoriaProdutoId = Guid.NewGuid(),
                Nome = "Lanche",
                Descricao = "Cadastro do primeiro Lanche",
            };

            //Act
            var result = _produtoHandler.Handle(command, default);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Produto_DeveRetornarVerdadeiro_QuandoAtualizar()
        {
            //Arrange
            var commandCadastrar = new CadastraProdutoCommand()
            {
                CategoriaProdutoId = Guid.NewGuid(),
                Nome = "Lanche",
                Descricao = "Cadastro do primeiro Lanche",
            };
            var dado = _produtoHandler.Handle(commandCadastrar, default).Result;

            var command = new AtualizaProdutoCommand()
            {
                Id = dado.Id,
                CategoriaProdutoId = dado.CategoriaProdutoId,
                Nome = dado.Nome,
                Descricao = "Alterando cadastro do primeiro Lanche",
            };

            //Act
            var result = _produtoHandler.Handle(command, default);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Produto_DeveRetornarVerdadeiro_QuandoRemover()
        {
            //Arrange
            var commandCadastrar = new CadastraProdutoCommand()
            {
                CategoriaProdutoId = Guid.NewGuid(),
                Nome = "Lanche",
                Descricao = "Cadastro do primeiro Lanche",
            };
            var dado = _produtoHandler.Handle(commandCadastrar, default).Result;

            var command = new DeletaProdutoCommand()
            {
                Id = dado.Id,
            };

            //Act
            var result = _produtoHandler.Handle(command, default);

            //Assert
            Assert.NotNull(result);
        }
    }
}
