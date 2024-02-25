using Domain.Validations.TabelaPrecos.Base;

namespace Domain.Validations.TabelaPrecos
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