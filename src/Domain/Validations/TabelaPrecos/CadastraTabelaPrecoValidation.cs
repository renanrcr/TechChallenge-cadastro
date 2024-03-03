using Domain.Validations.TabelaPrecos.Base;

namespace Domain.Validations.TabelaPrecos
{
    public class CadastraTabelaPrecoValidation : TabelaPrecoBaseValidation
    {
        public CadastraTabelaPrecoValidation()
        {
            ValidarId();
            ValidarIdProduto();
            ValidarPreco();
        }
    }
}