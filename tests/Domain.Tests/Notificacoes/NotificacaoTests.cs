using Domain.Adapters;
using Domain.Notificacoes;
using Moq;

namespace Domain.Tests.Notificacoes
{
    public class NotificacaoTests
    {
        private readonly INotificador _notificador;

        public NotificacaoTests()
        {
            _notificador = new Notificador();
        }

        [Fact]
        public void Notificador_DeveRetornarVerdadeiro_QuandoTemNotificacao()
        {
            //Arrange
            var mensagem = "Adicionando mensagem de retorno.";

            //Act
            _notificador.Handle(new Notificacao(mensagem));

            //Assert
            Assert.True(_notificador.TemNotificacao());
        }

        [Fact]
        public void Notificador_DeveRetornarVerdadeiro_QuandoNaoTemNotificacao()
        {
            //Arrange

            //Act

            //Assert
            Assert.False(_notificador.TemNotificacao());
        }
    }
}
