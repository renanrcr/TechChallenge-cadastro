using FluentValidation.Results;
using TechChallenge.src.Core.Application.Notificacoes;
using TechChallenge.src.Core.Domain.Adapters;

namespace TechChallenge.src.Core.Application.Services
{
    public class BaseService
    {
        private readonly INotificador _notificador;

        protected BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }
    }
}