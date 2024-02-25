using Domain.Adapters;
using Domain.Validations.Clientes.Base;

namespace Domain.Validations.Clientes
{
    public class CadastraClienteValidation : ClienteBaseValidation
    {
        public CadastraClienteValidation(IClienteRepository clienteRepository)
            : base(clienteRepository)
        {
            ValidarDataCadastro();
            ValidarNome();
            ValidarEmail();
        }
    }
}