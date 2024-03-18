using Domain.ValueObjects;

namespace Domain.Tests.ValueObjects
{
    public class CPFTests
    {
        [Fact]
        public void CPF_DeveRetornarVerdadeiro_QuandoEhValido()
        {
            //Arrange

            //Act
            var cpf = new CPF("24364711004");

            //Assert
            Assert.True(cpf.IsValidado);
        }

        [Fact]
        public void CPF_DeveRetornarFalso_QuandoNaoEhValido()
        {
            //Arrange

            //Act
            var cpf = new CPF("24364711777");

            //Assert
            Assert.False(cpf.IsValidado);
        }

        [Fact]
        public void CPF_DeveRetornarVerdadeiro_QuandoEstiverFormatado()
        {
            //Arrange

            //Act
            var cpf = new CPF("243.647.110-04");

            //Assert
            Assert.True(cpf.IsValidado);
        }
    }
}
