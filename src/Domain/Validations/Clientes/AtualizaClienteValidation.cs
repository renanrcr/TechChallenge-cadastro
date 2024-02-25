using Domain.Adapters;
using Domain.Validations.Clientes.Base;

namespace Domain.Validations.Clientes
{
    public class AtualizaClienteValidation : ClienteBaseValidation
    {
        public AtualizaClienteValidation(IClienteRepository clienteRepository)
            : base(clienteRepository)
        {
            ValidarExisteClienteCadastrado();
            ValidarNome();
            ValidarEmail();
            ValidarDataAtualizacao();
        }
    }
}