using FluentValidation;
using TechChallenge.src.Core.Domain.Adapters;
using TechChallenge.src.Core.Domain.Entities;

namespace TechChallenge.src.Core.Application.Validations.Clientes.Base
{
    public class ClienteBaseValidation : ValidationBase<Cliente>
    {
        IClienteRepository _clienteRepository;

        public ClienteBaseValidation(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;

            ValidarId();
        }

        public void ValidarNome()
        {
            RuleFor(x => x.Nome).NotNull().NotEmpty().WithMessage("Informe um nome.");
        }

        public void ValidarEmail()
        {
            RuleFor(s => s.Email).NotEmpty().WithMessage("É obrigatório um e-mail.")
                     .EmailAddress().WithMessage("É necessário um e-mail válido.")
                     .MustAsync(ExisteEmailCadastradoAsync).WithMessage("Este e-mail já existe em nossa base.");
        }

        public void ValidarExisteClienteCadastrado()
        {
            RuleFor(s => s.Id).NotEmpty()
                .MustAsync(ExisteClienteAsync).WithMessage("Cliente não encontrado na base de dados.");
        }

        private async Task<bool> ExisteEmailCadastradoAsync(string email, CancellationToken token)
        {
            return await _clienteRepository.Existe(x => x.Email == email);
        }

        private async Task<bool> ExisteClienteAsync(Guid id, CancellationToken token)
        {
            return await _clienteRepository.Existe(x => x.Id == id);
        }
    }
}