using Application.AutoMapper;
using Application.Commands.TabelaPrecos;
using AutoMapper;
using Domain.Adapters;
using Infrastructure.Tests.Adapters;
using Moq;
using TechChallenge.src.Handlers;

namespace Application.Tests.Services.Handlers
{
    public class TabelaPrecoHandlerTests
    {
        private readonly TabelaPrecoHandler _tabelaPrecoHandler;

        public TabelaPrecoHandlerTests()
        {
            var tabelaPrecoRepository = ITabelaPrecoRepositoryMock.GetMock();

            var notificacao = new Mock<INotificador>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperConfig>());
            var mapper = config.CreateMapper();

            _tabelaPrecoHandler = new TabelaPrecoHandler(notificacao.Object, tabelaPrecoRepository, mapper);
        }

        [Fact]
        public async void TabelaPreco_DeveRetornarVerdadeiro_QuandoCadastrarNovo()
        {
            //Arrange
            var command = new CadastraTabelaPrecoCommand()
            {
                ProdutoId = Guid.NewGuid(),
                Preco = 29.90m,
            };

            //Act
            var result = await _tabelaPrecoHandler.Handle(command, default);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async void TabelaPreco_DeveRetornarVerdadeiro_QuandoAtualizar()
        {
            //Arrange
            var commandCadastrar = new CadastraTabelaPrecoCommand()
            {
                ProdutoId = Guid.NewGuid(),
                Preco = 29.90m,
            };
            var dado = await _tabelaPrecoHandler.Handle(commandCadastrar, default);

            var command = new AtualizaTabelaPrecoCommand()
            {
                Id = dado.Id,
                Preco = 22m,
            };

            //Act
            var result = await _tabelaPrecoHandler.Handle(command, default);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async void TabelaPreco_DeveRetornarVerdadeiro_QuandoRemover()
        {
            //Arrange
            var commandCadastrar = new CadastraTabelaPrecoCommand()
            {
                ProdutoId = Guid.NewGuid(),
                Preco = 29.90m,
            };
            var dado = await _tabelaPrecoHandler.Handle(commandCadastrar, default);

            var command = new DeletaTabelaPrecoCommand()
            {
                Id = dado.Id,
            };

            //Act
            var result = await _tabelaPrecoHandler.Handle(command, default);

            //Assert
            Assert.NotNull(result);
        }
    }
}