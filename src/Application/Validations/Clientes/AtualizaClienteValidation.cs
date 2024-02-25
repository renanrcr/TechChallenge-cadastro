using TechChallenge.src.Core.Application.Validations.Clientes.Base;
using TechChallenge.src.Core.Domain.Adapters;

namespace TechChallenge.src.Core.Application.Validations.Clientes
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