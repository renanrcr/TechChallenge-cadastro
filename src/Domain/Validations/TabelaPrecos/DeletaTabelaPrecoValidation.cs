using Domain.Validations.TabelaPrecos.Base;

namespace Domain.Validations.TabelaPrecos
{
    public class DeletaTabelaPrecoValidation : TabelaPrecoBaseValidation
    {
        public DeletaTabelaPrecoValidation()
        {
            ValidarDataExclusao();
        }
    }
}