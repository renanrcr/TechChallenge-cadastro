using Application.AutoMapper;
using Application.Commands.CategoriaProdutos;
using AutoMapper;
using Domain.Adapters;
using Domain.Notificacoes;
using Infrastructure.Tests.Adapters;
using TechChallenge.src.Handlers;

namespace Application.Tests.Services.Handlers
{
    public class CategoriaProdutoHandlerTests
    {
        private readonly ICategoriaProdutoRepository _categoriaProdutoRepository;
        private readonly INotificador _notificador;
        private readonly IMapper _mapper;
        private readonly CategoriaProdutoHandler _categoriaProdutoHandler;

        public CategoriaProdutoHandlerTests()
        {
            _categoriaProdutoRepository = ICategoriaProdutoRepositoryMock.GetMock();
            _notificador = new Notificador();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperConfig>());
            _mapper = config.CreateMapper();

            _categoriaProdutoHandler = new CategoriaProdutoHandler(_notificador, _categoriaProdutoRepository, _mapper);
        }

        [Fact]
        public async void CategoriaProduto_DeveRetornarVerdadeiro_QuandoCadastrarNovo()
        {
            //Arrange
            var command = new CadastraCategoriaProdutoCommand()
            {
                Descricao = "Categoria Lanche",
            };

            //Act
            var result = await _categoriaProdutoHandler.Handle(command, default);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async void CategoriaProduto_DeveRetornarFalso_QuandoNaoAtualizar()
        {
            //Arrange
            var commandCadastrar = new CadastraCategoriaProdutoCommand()
            {
                Descricao = "Categoria Lanche",
            };
            var dado = await _categoriaProdutoHandler.Handle(commandCadastrar, default);

            var command = new AtualizaCategoriaProdutoCommand()
            {
                Id = dado.Id,
                Descricao = "Alterando categoria Lanche",
            };

            //Act
            var result = await _categoriaProdutoHandler.Handle(command, default);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async void CategoriaProduto_DeveRetornarVerdadeiro_QuandoRemover()
        {
            //Arrange
            var commandCadastrar = new CadastraCategoriaProdutoCommand()
            {
                Descricao = "Categoria Lanche",
            };
            var dado = await _categoriaProdutoHandler.Handle(commandCadastrar, default);

            var command = new DeletaCategoriaProdutoCommand()
            {
                Id = dado.Id,
            };

            //Act
            var result = _categoriaProdutoHandler.Handle(command, default);

            //Assert
            Assert.NotNull(result);
        }
    }
}
