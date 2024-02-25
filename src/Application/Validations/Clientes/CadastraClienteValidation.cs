using TechChallenge.src.Core.Application.Validations.Clientes.Base;
using TechChallenge.src.Core.Domain.Adapters;

namespace TechChallenge.src.Core.Application.Validations.Clientes
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