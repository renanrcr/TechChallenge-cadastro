using TechChallenge.src.Core.Application.Validations.TabelaPrecos.Base;

namespace TechChallenge.src.Core.Application.Validations.TabelaPrecos
{
    public class DeletaTabelaPrecoValidation : TabelaPrecoBaseValidation
    {
        public DeletaTabelaPrecoValidation()
        {
            ValidarDataExclusao();
        }
    }
}