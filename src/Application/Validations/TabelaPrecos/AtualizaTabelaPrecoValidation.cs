using TechChallenge.src.Core.Application.Validations.TabelaPrecos.Base;

namespace TechChallenge.src.Core.Application.Validations.TabelaPrecos
{
    public class AtualizaTabelaPrecoValidation : TabelaPrecoBaseValidation
    {
        public AtualizaTabelaPrecoValidation()
        {
            ValidarIdProduto();
            ValidarPreco();
            ValidarDataAtualizacao();
        }
    }
}