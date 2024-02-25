using TechChallenge.src.Core.Application.Notificacoes;

namespace TechChallenge.src.Core.Domain.Adapters
{
    public interface INotificador
    {
        bool TemNotificacao();

        object ObterNotificacoes();

        void Handle(Notificacao notificacao);
    }
}