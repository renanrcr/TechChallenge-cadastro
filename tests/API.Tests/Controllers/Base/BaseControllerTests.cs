using Domain.Adapters;
using Moq;
using TechChallenge.Api.Controllers.Base;

namespace API.Tests.Controllers.Base
{
    public class BaseControllerTests : BaseController
    {
        private readonly BaseController _baseController;
        private readonly INotificador _notificador;

        public BaseControllerTests() 
            : base(new Mock<INotificador>().Object)
        {
            _notificador = new Mock<INotificador>().Object;
            _baseController = this;
        }

        [Fact]
        public void BaseController_DeveRetornarVerdadeiro_QuandoNaoEhNulo()
        {
            //Arrange

            //Act

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(_baseController);
            });
        }

        [Fact]
        public void BaseController_DeveRetornarVerdadeiro_QuandoNaoTemNotificacao()
        {
            //Arrange

            //Act

            //Assert
            Assert.Multiple(() =>
            {
                Assert.False(_notificador.TemNotificacao());
            });
        }
    }
}
