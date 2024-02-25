using TechChallenge.src.Core.Application.Validations.TabelaPrecos.Base;

namespace TechChallenge.src.Core.Application.Validations.TabelaPrecos
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