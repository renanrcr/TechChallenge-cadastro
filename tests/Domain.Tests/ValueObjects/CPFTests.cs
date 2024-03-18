using Domain.ValueObjects;

namespace Domain.Tests.ValueObjects
{
    public class CPFTest
    {
        [Fact]
        public void CPF_DeveRetornarVerdadeiro_QuandoEhValido()
        {
            //Arrange

            //Act
            var cpf = new CPF("24364711004");

            //Assert
            Assert.Multiple(() =>
            {
                Assert.True(cpf.IsValidado);
            });
        }

        [Fact]
        public void CPF_DeveRetornarFalso_QuandoNaoEhValido()
        {
            //Arrange

            //Act
            var cpf = new CPF("24364711777");

            //Assert
            Assert.Multiple(() =>
            {
                Assert.False(cpf.IsValidado);
            });
        }
    }
}
