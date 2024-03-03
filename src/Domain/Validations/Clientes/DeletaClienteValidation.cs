using Domain.Adapters;
using Domain.Validations.Clientes.Base;

namespace Domain.Validations.Clientes
{
    public class DeletaClienteValidation : ClienteBaseValidation
    {
        public DeletaClienteValidation(IClienteRepository clienteRepository)
            : base(clienteRepository)
        {
            ValidarExisteClienteCadastrado();
            ValidarDataExclusao();
        }
    }
}