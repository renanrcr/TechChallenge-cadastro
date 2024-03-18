using FluentValidation;
using Domain.Adapters;
using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Validations.Clientes.Base
{
    public class ClienteBaseValidation : ValidationBase<Cliente>
    {
        IClienteRepository _clienteRepository;

        public ClienteBaseValidation(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;

            ValidarId();
            ValidarValorCPF();
            ValidarEmail();
        }

        public void ValidarEmail()
        {
            When(s => !string.IsNullOrEmpty(s.Email), () => {
                RuleFor(s => s.Email)
                .EmailAddress().WithMessage("É necessário um e-mail válido.")
                     .MustAsync(ExisteEmailCadastradoAsync).WithMessage("Este e-mail já existe em nossa base.");
            });
        }

        public void ValidarValorCPF()
        {
            RuleFor(x => x.CPF).Must((x, cpf) =>
            {
                return !(!string.IsNullOrEmpty(cpf) && ValidarCPF(x.CPF));
            }).WithMessage("Informe um CPF válido.");
        }

        private bool ValidarCPF(string? valor) => new CPF(valor).IsValidado;

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